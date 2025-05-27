using Example_FastEndpoints_RpcServer.Contracts;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.RemoteProcedureCallsExamples.RemoteCommandBus;

public class Endpoint : EndpointWithoutRequest<int>
{
    public override void Configure()
    {
        Get("/rpc/command");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new AddNumbersCommand
        {
            FirstNumber = Query<int>("firstNumber"),
            SecondNumber = Query<int>("secondNumber"),
        };

        var result = await command.RemoteExecuteAsync();

        await SendOkAsync(result.Result, ct);
    }
}
