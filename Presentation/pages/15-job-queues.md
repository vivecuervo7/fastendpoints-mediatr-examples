<h1>FastEndpoints</h1>
<h2>Job queues</h2>

<div class="content">
  <v-drag pos="52,176,375,_">
    <div class="box">
```csharp {all|none}{at:1}
class Endpoint<TRequest>
```
      <hr/>
```csharp {all|1|2|2|none}{at:1}
var command = new ExampleCommand();
var trackingId = await command.QueueJobAsync(ct: ct);
```
<div v-click="4">
  <hr/>
```csharp {all|none}{at:5}
var result = await JobTracker<ExampleCommand>
    .GetJobResultAsync<int>(trackingId, ct);
```
</div>
<div v-click="5">
  <hr/>
```csharp {all|none}{at:6}
await JobTracker<ExampleCommand>
    .CancelJobAsync(trackingId, ct);
```
</div>
    </div>
  </v-drag>

  <v-drag pos="553,164,112,_">
    <div v-click="3" class="floating-label text-pink-500" data-id="job-queue" v-mark.gray.box="{ at: 3, iterations: 1, animationDuration: 350 }">Job Queue</div>
  </v-drag>
  <FancyArrow v-click="3" x1="422" y1="200" x2="545" y2="180" color="gray" arc="0.15" head-size="15" width="1" class="z-100" seed="40" />

  <v-drag pos="546,221,390,_">
    <div class="box" data-id="command-handler" v-click="6">
````md magic-move {at:7}
```csharp
class Handler : ICommandHandler<ExampleCommand, int>
```
```csharp {all|none|none|none|none}{at:6}
class Handler(IJobTracker<ExampleCommand> tracker)
    : ICommandHandler<ExampleCommand, int>
```
````
      <hr/>
```csharp {all|none}{at:7}
Task<int> ExecuteAsync(
    ExampleCommand command,
    CancellationToken ct);
```
<div v-click="8">
  <hr/>
````md magic-move {at:9}
```csharp
var jobResult = new JobResult<int>(totalSteps: 100);
```
```csharp {2}
var jobResult = new JobResult<int>(totalSteps: 100);
jobResult.CurrentStep = 30;
```
```csharp {3|none}
var jobResult = new JobResult<int>(totalSteps: 100);
jobResult.CurrentStep = 30;
jobResult.Result = 123;
```
````
</div>
<div v-click="11">
  <hr/>
```csharp
await tracker
    .StoreJobResultAsync(job.TrackingID, jobResult, ct);
```
</div>
    </div>
  </v-drag>
</div>

<style>
  .slidev-vclick-hidden {
    display: none;
  }
</style>

<!--
So, this still uses the exact same command from our previous example. [click]

The only difference is that instead of invoking it directly with `ExecuteAsync` [click], we're calling `QueueJobAsync` instead.

[click] Now, `QueueJobAsync` simply adds the job the to queue, and returns a tracking ID.

[click] We can use that tracking ID to check the progress of the job [click], or cancel it if required.

[click] The queue will then be responsible for executing the command in the background, depending on how we've configured our parallelism etc.

[click] If we do want to implement progress tracking, we need to inject an `IJobTracker` into our handler and have our command implement an `ITrackableJob` interface.

[click] We then create a new `JobResult`, where we can set the total number of steps, [click] and from there, we can update the current step as the job progresses [click], and finally, we can set the result of the job.

[click] Now, as mentioned, these jobs are designed to be durable, and as this method indicates, we need to set up some way to store the jobs and their results.
-->

---

<h1>FastEndpoints</h1>
<h2>Job queues</h2>

<v-drag pos="52,176,385,_">
<div class="box">

````md magic-move {at:1}
```csharp {all|all|none|none}{at:1}
class JobRecord : IJobStorageRecord
```
```csharp {all|none|none|none|none|none|none|none|all}
class JobRecord : IJobStorageRecord, IJobResultStorage
```
````

<hr/>

````md magic-move {at:1}
```csharp {all|none|all|none|none}{at:1}
Guid TrackingID { get; set; }
object Command { get; set; }
```
```csharp {3|none|none|none|none|none|none}
Guid TrackingID { get; set; }
object Command { get; set; }
object? Result { get; set; }
```
````

<hr/>

````md magic-move {at:1}
```csharp {all|none|none|all|none|none}{at:1}
TCommand GetCommand<TCommand>();

void SetCommand<TCommand>(TCommand command);
```
```csharp {5,7|none|none|none|none|none}
TCommand GetCommand<TCommand>();

void SetCommand<TCommand>(TCommand command);

TResult? GetResult<TResult>();

void SetResult<TResult>(TResult result);
```
````

</div>
</v-drag>

<v-drag pos="480,176,405,_">
<div class="box" v-click="7">

````md magic-move {at:8}
```csharp {all|all|none}{at:8}
class JobStorageProvider
    : IJobStorageProvider<JobRecord>
```
```csharp {all|none}
class JobStorageProvider
    : IJobStorageProvider<JobRecord>, IJobResultProvider
```
````

<hr/>

````md magic-move {at:8}
```csharp {all|none|all|none}{at:8}
Task StoreJobAsync(TStorageRecord r, CancellationToken ct);

Task CancelJobAsync(Guid trackingId, CancellationToken ct);
```
```csharp {5-11}
Task StoreJobAsync(TStorageRecord r, CancellationToken ct);

Task CancelJobAsync(Guid trackingId, CancellationToken ct);

Task StoreJobResultAsync<TResult>(Guid trackingId,
    TResult result,
    CancellationToken ct);

Task<TResult?> GetJobResultAsync<TResult>(
    Guid trackingId,
    CancellationToken ct);
```
````
</div>
</v-drag>

<!--
Outside of calling `AddJobQueues` in our `Program.cs`, we also need to implement a job storage record.

[click] This is a class that implements `IJobStorageRecord` [click], which among a few other properties is used to store the job's tracking ID and the command itself.

[click] The `Get` and `SetCommand` methods here are used to customize serialization of the command.

[click] If we need to store the _result_ of the job, we can also implement `IJobResultStorage`.

Once we add this, we also need to provide a property for the result [click], and implement the `Get` and `SetResult` methods to handle serialization of the result. [click]

With our job storage record ready to persist, we also need to implement a job storage provider. [click]

We really have our choice of persistence mechanism here [click], as long as we implement the `IJobStorageProvider` interface.

[click] Again, while these aren't _all_ the methods we need to implement, the ones we'll actively use are along the lines of explicitly storing or canceling jobs.

And similar to the `JobRecord` [click], if we need to store the result we can also implement `IJobResultProvider` [click], and implement the methods.

[click] So, fairly easy to get these background tasks up and running, just with that bit of overhead to add some form of persistence.
-->
