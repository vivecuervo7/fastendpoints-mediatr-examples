using Example_FastEndpoints_RpcServer.Contracts;
using FastEndpoints;

namespace Example_FastEndpoints_RpcServer.Api;

public class AddNumbersCommandHandler : ICommandHandler<AddNumbersCommand, AddNumbersCommandResult>
{
    public Task<AddNumbersCommandResult> ExecuteAsync(
        AddNumbersCommand command,
        CancellationToken ct
    )
    {
        var result = new AddNumbersCommandResult
        {
            Result = command.FirstNumber + command.SecondNumber
        };

        return Task.FromResult(result);
    }
}
