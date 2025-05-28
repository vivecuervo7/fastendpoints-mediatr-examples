using Example_FastEndpoints_RpcServer.Contracts;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.RemoteProcedureCallsExamples.RemoteEventQueue;

public class OnUserCreatedFirstEventHandler(ILogger<OnUserCreatedFirstEventHandler> logger)
    : IEventHandler<UserCreatedEvent>
{
    public Task HandleAsync(UserCreatedEvent ev, CancellationToken ct)
    {
        logger.LogInformation("First event handler: {User}", ev.Username);
        return Task.CompletedTask;
    }
}
