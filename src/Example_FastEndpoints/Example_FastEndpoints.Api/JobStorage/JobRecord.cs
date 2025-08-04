using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using FastEndpoints;

namespace Example_FastEndpoints.Api.JobStorage;

// See: https://github.com/FastEndpoints/Job-Queue-EF-Core-Demo/blob/main/src/Storage/JobRecord.cs

public class JobRecord : IJobStorageRecord, IJobResultStorage
{
    public Guid Id { get; set; }
    public string QueueID { get; set; } = string.Empty;
    public Guid TrackingID { get; set; }
    public DateTime ExecuteAfter { get; set; }
    public DateTime ExpireOn { get; set; }
    public bool IsComplete { get; set; }

    public string CommandJson { get; set; } = string.Empty;
    public string? ResultJson { get; set; }

    [NotMapped]
    public object Command { get; set; } = default!;

    [NotMapped]
    public object? Result { get; set; }

    TCommand IJobStorageRecord.GetCommand<TCommand>() =>
        JsonSerializer.Deserialize<TCommand>(CommandJson)!;

    void IJobStorageRecord.SetCommand<TCommand>(TCommand command) =>
        CommandJson = JsonSerializer.Serialize(command);

    TResult? IJobResultStorage.GetResult<TResult>()
        where TResult : default =>
        ResultJson is not null ? JsonSerializer.Deserialize<TResult>(ResultJson) : default;

    void IJobResultStorage.SetResult<TResult>(TResult result) =>
        ResultJson = JsonSerializer.Serialize(result);
}
