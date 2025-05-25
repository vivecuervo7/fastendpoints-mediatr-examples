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
        await PublishAsync(new ExampleEvent { Text = "This is an example", }, Mode.WaitForAll, ct);
        await SendOkAsync(ct);
    }
}
