using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.EventBusExample;

public class FirstEventHandler(ILogger<ExampleEvent> logger) : IEventHandler<ExampleEvent>
{
    public Task HandleAsync(ExampleEvent ev, CancellationToken ct)
    {
        logger.LogInformation("{Handler}: {Text}", nameof(FirstEventHandler), ev.Text);
        return Task.CompletedTask;
    }
}
