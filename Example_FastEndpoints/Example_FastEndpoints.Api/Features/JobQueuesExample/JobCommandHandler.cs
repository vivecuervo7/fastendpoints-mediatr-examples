using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.JobQueuesExample;

public class JobCommandHandler(IJobTracker<JobCommand> tracker)
    : ICommandHandler<JobCommand, JobResult<string>>
{
    public async Task<JobResult<string>> ExecuteAsync(JobCommand job, CancellationToken ct)
    {
        var jobResult = new JobResult<string>(totalSteps: 100) { CurrentStatus = "starting..." };

        try
        {
            for (var i = 0; i < 100; i++)
            {
                jobResult.CurrentStep = i;
                jobResult.CurrentStatus = "in progress";
                await tracker.StoreJobResultAsync(job.TrackingID, jobResult, ct);
                await Task.Delay(150, ct);
            }

            jobResult.CurrentStatus = "finished";
            jobResult.Result = $"{job.FirstName} {job.LastName}";

            return jobResult;
        }
        catch (TaskCanceledException) when (ct.IsCancellationRequested)
        {
            jobResult.CurrentStatus = $"canceled at step: {jobResult.CurrentStep}";
            return jobResult;
        }
    }
}
