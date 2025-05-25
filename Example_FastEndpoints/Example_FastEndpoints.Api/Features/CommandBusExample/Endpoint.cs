using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.CommandBusExample;

public class Endpoint : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("/commands");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new DoubleValueCommand { Value = 3 };
        var result = await command.ExecuteAsync(ct);
        await SendOkAsync(result, ct);
    }
}
