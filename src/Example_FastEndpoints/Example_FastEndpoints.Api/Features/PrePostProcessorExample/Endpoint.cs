using Example_FastEndpoints.Api.Processors;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.PrePostProcessorExample;

public class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("/processors");

        // Also declared globally so this is unnecessary, but is included here for
        // the example of illustrating the use of a per-endpoint processor
        PreProcessor<StartServerTiming<EmptyRequest>>();
        PostProcessor<LogRequestDuration<EmptyRequest, Response>>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var timing = ProcessorState<ServerTimingState>();

        // Task without any specific timing
        await Task.Delay(30, ct);

        // Aggregated timings due to shared name (1/2)
        timing.StartNewActivity("Aggregated activity");
        await Task.Delay(20, ct);

        // Separate timings
        timing.StartNewActivity("Get user from database");
        await Task.Delay(new Random().Next(20, 50), ct);

        timing.StartNewActivity("Call some service");
        await Task.Delay(new Random().Next(50, 100), ct);

        timing.StartNewActivity("Call some other service");
        await Task.Delay(new Random().Next(50, 100), ct);

        timing.StartNewActivity("Save changes to database");
        await Task.Delay(new Random().Next(20, 50), ct);

        // Aggregated timings due to shared name (2/2)
        timing.StartNewActivity("Aggregated activity");
        await Task.Delay(20, ct);

        var response = new Response
        {
            Text = $"Request took {timing.GetTotalDuration().TotalMilliseconds:F2} ms"
        };

        await SendAsync(response, cancellation: ct);
    }
}
