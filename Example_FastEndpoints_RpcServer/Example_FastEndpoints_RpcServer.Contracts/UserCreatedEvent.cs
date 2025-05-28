using FastEndpoints;

namespace Example_FastEndpoints_RpcServer.Contracts;

public class UserCreatedEvent : IEvent
{
    public string Username { get; set; } = string.Empty;
}
