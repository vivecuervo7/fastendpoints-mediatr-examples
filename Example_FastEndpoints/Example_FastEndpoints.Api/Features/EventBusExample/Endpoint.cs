using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.EventBusExample;

public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/events");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var ev = new ExampleEvent { Text = "This is an example" };
        await ev.PublishAsync(Mode.WaitForAll, ct);
        await SendOkAsync(ct);
    }
}
