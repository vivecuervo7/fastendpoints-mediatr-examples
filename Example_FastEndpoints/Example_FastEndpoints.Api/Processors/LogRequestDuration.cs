using FastEndpoints;

namespace Example_FastEndpoints.Api.Processors;

public class LogRequestDuration<TRequest, TResponse>
    : PostProcessor<TRequest, ServerTimingState, TResponse>
{
    public override Task PostProcessAsync(
        IPostProcessorContext<TRequest, TResponse> context,
        ServerTimingState state,
        CancellationToken ct
    )
    {
        var logger = context.HttpContext.Resolve<ILogger<TRequest>>();

        logger.LogInformation(
            "Request to {Path} completed in {Duration} ms",
            context.HttpContext.Request.Path,
            state.GetTotalDuration().TotalMilliseconds
        );

        return Task.CompletedTask;
    }
}
