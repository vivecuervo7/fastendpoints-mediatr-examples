using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.CommandBusExample;

public class CommandLogger(ILogger<DoubleValueCommand> logger)
    : ICommandMiddleware<DoubleValueCommand, int>
{
    public async Task<int> ExecuteAsync(
        DoubleValueCommand command,
        CommandDelegate<int> next,
        CancellationToken ct
    )
    {
        logger.LogInformation("Executing command: {name}", command.GetType().Name);

        var result = await next();

        logger.LogInformation("Got result: {value}", result);

        return result;
    }
}
