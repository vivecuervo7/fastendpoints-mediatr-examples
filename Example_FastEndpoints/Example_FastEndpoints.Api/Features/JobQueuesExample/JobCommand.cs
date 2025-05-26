using System.ComponentModel.DataAnnotations.Schema;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.JobQueuesExample;

public class JobCommand : ITrackableJob<JobResult<string>>
{
    [NotMapped]
    public Guid TrackingID { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
