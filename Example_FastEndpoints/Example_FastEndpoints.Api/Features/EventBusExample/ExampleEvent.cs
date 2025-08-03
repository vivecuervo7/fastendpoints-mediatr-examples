using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.EventBusExample;

public class ExampleEvent : IEvent
{
    public string Text { get; set; } = string.Empty;
}
