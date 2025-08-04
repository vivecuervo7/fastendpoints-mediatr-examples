using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.EventBusExample;

public class Endpoint
    : Endpoint<
        Tbfuerbwifuweorinfbiuerhbgeuyrghuiegsdfgrtwegrthtrbhgiu4,
        Tnfoiurbgonoeriuwtrhrtehrtherthtbgj4riogfnw3ourghnion34
    >
{
    public override void Configure()
    {
        Get("/events");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await new ExampleEvent().PublishAsync(Mode.WaitForAll, ct);
        await SendOkAsync(ct);
    }
}
