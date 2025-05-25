using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.CommandBusExample;

public class DoubleValueCommandHandler : ICommandHandler<DoubleValueCommand, int>
{
    public Task<int> ExecuteAsync(DoubleValueCommand command, CancellationToken ct)
    {
        return Task.FromResult(command.Value * 2);
    }
}
