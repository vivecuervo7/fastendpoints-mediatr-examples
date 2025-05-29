using System.Runtime.CompilerServices;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.ServerSentEventsExample;

public class EventStream : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("/event-stream");
        Options(x => x.RequireCors(p => p.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendEventStreamAsync("event", GetDataStream(ct));
    }

    private static async IAsyncEnumerable<object> GetDataStream(
        [EnumeratorCancellation] CancellationToken ct
    )
    {
        while (!ct.IsCancellationRequested)
        {
            yield return new { Guid = Guid.NewGuid() };
            await Task.Delay(1000);
        }
    }
}
