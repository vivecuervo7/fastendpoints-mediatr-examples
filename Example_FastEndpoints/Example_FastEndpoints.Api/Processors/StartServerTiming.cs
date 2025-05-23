using FastEndpoints;

namespace Example_FastEndpoints.Api.Processors;

public class StartServerTiming<TRequest> : PreProcessor<TRequest, ServerTimingState>
{
    public override Task PreProcessAsync(
        IPreProcessorContext<TRequest> context,
        ServerTimingState state,
        CancellationToken ct
    )
    {
        return Task.CompletedTask;
    }
}
