using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.JobQueuesExample;

public class Endpoint : Endpoint<JobCommand, string>
{
    public override void Configure()
    {
        Post("job-queue");
    }

    public override async Task HandleAsync(JobCommand req, CancellationToken ct)
    {
        var command = req;
        var trackingId = await command.QueueJobAsync(ct: ct);

        await SendCreatedAtAsync<ResultEndpoint>(
            new { trackingId },
            trackingId.ToString(),
            cancellation: ct
        );
    }
}

public class CancelEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("job-queue/cancel/{trackingId:guid}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var trackingId = Route<Guid>("trackingId");
        await JobTracker<JobCommand>.CancelJobAsync(trackingId, ct);
        await SendOkAsync(ct);
    }
}

public class ResultEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("job-queue/result/{trackingId:guid}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var trackingId = Route<Guid>("trackingId");

        var jobResult = await JobTracker<JobCommand>.GetJobResultAsync<JobResult<string>>(
            trackingId,
            ct
        );

        if (jobResult is null)
        {
            await SendOkAsync("Job not started", cancellation: ct);
            return;
        }

        if (jobResult.IsComplete)
        {
            await SendOkAsync($"Full name: {jobResult.Result}", cancellation: ct);
            return;
        }

        await SendOkAsync(
            $"[{jobResult.CurrentStep} / {jobResult.TotalSteps}] | status: {jobResult.CurrentStatus}",
            cancellation: ct
        );
    }
}
