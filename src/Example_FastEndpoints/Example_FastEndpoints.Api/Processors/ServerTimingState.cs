using System.Diagnostics;

namespace Example_FastEndpoints.Api.Processors;

public class ServerTimingState
{
    private readonly Dictionary<string, Stopwatch> _timers = [];
    private readonly Lock _lock = new();
    private string? _currentActivity;

    public ServerTimingState()
    {
        var sw = new Stopwatch();
        sw.Start();
        _timers.Add("Total", sw);
    }

    public TimeSpan GetTotalDuration()
    {
        return _timers.TryGetValue("Total", out var stopwatch) ? stopwatch.Elapsed : TimeSpan.Zero;
    }

    public Stopwatch StartNewActivity(string name)
    {
        lock (_lock)
        {
            // Stop the currently running activity, if any
            if (
                _currentActivity != null
                && _timers.TryGetValue(_currentActivity, out var prevStopwatch)
                && prevStopwatch.IsRunning
            )
            {
                prevStopwatch.Stop();
            }

            // Start (or restart) the new activity
            if (!_timers.TryGetValue(name, out var stopwatch))
            {
                stopwatch = new Stopwatch();
                _timers[name] = stopwatch;
            }

            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }

            _currentActivity = name;
            return stopwatch;
        }
    }

    public void Stop(string name)
    {
        lock (_lock)
        {
            if (_timers.TryGetValue(name, out var stopwatch) && stopwatch.IsRunning)
            {
                stopwatch.Stop();
                if (_currentActivity == name)
                {
                    _currentActivity = null;
                }
            }
        }
    }

    private void StopAll()
    {
        lock (_lock)
        {
            foreach (var sw in _timers.Values)
            {
                if (sw.IsRunning)
                {
                    sw.Stop();
                }
            }
        }
    }

    public string ToServerTimingHeader()
    {
        StopAll();
        return string.Join(", ", _timers.Select(FormatAsHeader()));
    }

    private static Func<KeyValuePair<string, Stopwatch>, string> FormatAsHeader()
    {
        return kvp =>
        {
            return $"{ToCamelCase(kvp.Key)};dur={kvp.Value.Elapsed.TotalMilliseconds:F2};desc=\"{kvp.Key}\"";
        };
    }

    private static string ToCamelCase(string input)
    {
        return string.Concat(
            input
                .Split(' ')
                .Select(
                    (w, i) =>
                        i == 0
                            ? char.ToLowerInvariant(w[0]) + w[1..]
                            : char.ToUpperInvariant(w[0]) + w[1..]
                )
        );
    }
}
