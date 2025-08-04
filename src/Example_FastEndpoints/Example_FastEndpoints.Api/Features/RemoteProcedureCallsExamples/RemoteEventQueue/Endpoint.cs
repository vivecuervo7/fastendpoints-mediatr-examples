using Example_FastEndpoints_RpcServer.Contracts;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.RemoteProcedureCallsExamples.RemoteEventQueue;

public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/rpc/event");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var username = Query<string>("username") ?? string.Empty;
        var ev = new UserCreatedEvent { Username = username };
        await ev.RemotePublishAsync();
        await SendOkAsync(ct);
    }
}
