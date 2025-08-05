<h1>FastEndpoints</h1>
<h2>Events, Commands and Queues</h2>

<ul class="content">
  <li>FastEndpoints allows us to decouple our code via <strong>events</strong> and <strong>commands</strong></li>
  <v-clicks>
    <li>Events have a one-to-many relationship with handlers and do not return results</li>
    <li>Commands have a one-to-one relationship with handlers, and may return a result</li>
    <li>Job queues give us a way to easily fire off commands as background jobs</li>
  </v-clicks>
</ul>

<!--
If we’re feeling particularly nostalgic, FastEndpoints allows for that familiar Mediator-like handler pattern as well.

This allows for what is a very simple starting point to organically grow into a solution that's more reminiscent of a typical MediatR-based solution; or, perhaps we just want to extract some common logic without necessarily wrapping it a service.

FastEndpoint’s commands and events reflect the familiar MediatR request / response pattern, as well as their notifications pattern.

[click] Events are essentially a one-to-many fire-and-forget, while commands [click] have a one-to-one relationship with handlers, and may return a result.

[click] We also have the ability to queue up commands to be run in the background &mdash; useful for long-running tasks where we don't want to block a user's interaction with a web page.
-->

---

<h1>FastEndpoints</h1>
<h2>Events</h2>

<div class="content">

<v-drag pos="52,176,350,_">
  <div class="box" data-id="endpoint">
```csharp {all|none}{at:1}
class Endpoint<TRequest>
```
  <hr/>
````md magic-move
```csharp {all|2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, cancellation: ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, cancellation: ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, cancellation: ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, cancellation: ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForAny, ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForAll, ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForNone, ct);
```
```csharp {2}{at:1}
var _event = new ExampleEvent();
await _event.PublishAsync(Mode.WaitForNone, ct);
```
````
  </div>
</v-drag>

  <v-drag pos="568,352,350,_">
    <div class="box" data-id="first" v-click="2">
```csharp
class Handler_1 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp {all|none|all}{at:3}
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
    </div>
  </v-drag>

  <FancyArrow v-click="2" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="gray" head-size="15" width="1" class="z-100" seed="1" />
  <FancyArrow v-click="[5,7]" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="pink" head-size="15" width="3" class="z-100" seed="1" />

  <v-drag pos="608,204,350,_">
    <div class="box" data-id="second" v-click="5">
```csharp
class Handler_2 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
    </div>
  </v-drag>

  <FancyArrow v-click="5" q1="[data-id=endpoint]" q2="[data-id=second]" pos1="right" pos2="left" color="gray" head-size="15" width="1" class="z-100" seed="2" />
  <FancyArrow v-click="[6,7]" q1="[data-id=endpoint]" q2="[data-id=second]" pos1="right" pos2="left" color="pink" head-size="15" width="3" class="z-100" seed="2" />

  <v-drag pos="133,412,350,_">
    <div class="box" data-id="third" v-click="5">
```csharp
class Handler_3 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
    </div>
  </v-drag>

  <FancyArrow v-click="5" q1="[data-id=endpoint]" q2="[data-id=third]" pos1="bottom" pos2="top" color="gray" head-size="15" width="1" class="z-100" seed="3" />
  <FancyArrow v-click="[6,7]" q1="[data-id=endpoint]" q2="[data-id=third]" pos1="bottom" pos2="top" color="pink" head-size="15" width="3" class="z-100" seed="3" />
</div>

<!--
Raising events in FastEndpoints is pretty straightforward.

Create an event inside an `Endpoint` [click], and publish it with `PublishAsync`.

[click] Any event handlers with that event provided as its [click] type parameter will be invoked. [click]

We can wait for any one of our handlers to complete execution... [click]

Or we can wait for all of them... [click]

Or we can wait for none. [click]

Events can also be invoked from outside of an endpoint if required [click], by having our event class implement `IEvent`, which exposes a `PublishAsync` method on the event itself.
-->

---

<h1>FastEndpoints</h1>
<h2>Commands</h2>

<div class="content">
  <v-drag pos="52,176,315,_">
    <div class="box" data-id="command-endpoint">
```csharp {all|none}{at:1}
class Endpoint<TRequest>
```
      <hr/>
```csharp {all|2}{at:1}
var command = new ExampleCommand();
var result = await command.ExecuteAsync(ct);
```
    </div>
  </v-drag>

  <v-drag pos="491,176,390,_">
    <div class="box" data-id="command-handler" v-click="[2,5]">
```csharp {all|none}{at:3}
class Handler : ICommandHandler<ExampleCommand, int>
```
      <hr/>
```csharp {all|none}{at:3}
Task<int> ExecuteAsync(
    ExampleCommand command,
    CancellationToken ct);
```
<div v-click="[3,4]" class="v-click-foo">
  <hr/>
```csharp
return result;
```
</div>
<div v-click="4" class="v-click-foo">
  <hr/>

```csharp {all|1}{at:3}
AddError("Error message");

return result;
```
</div>
    </div>
  </v-drag>

  <v-drag pos="491,176,390,_">
    <div class="box" data-id="middleware" v-click="5">
```csharp {all|none}{at:6}
class Middleware
    : ICommandMiddleware<ExampleCommand, int>
```
      <hr/>
```csharp {all|none}{at:6}
Task<int> ExecuteAsync(
    ExampleCommand command,
    CommandDelegate<int> next,
    CancellationToken ct);
```
<hr/>
<div data-id="middleware-before">
```csharp {all|none|all}{at:6}
// Code to execute before command
```
</div>
```csharp
var result = await next();
```
```csharp {all|none|none|all}{at:6}
// Code to execute after command
```
<div data-id="middleware-after">
```csharp {all|none}{at:6}
return result;
```
</div>
    </div>
  </v-drag>

  <FancyArrow v-click="2" x1="362" y1="245" x2="493" y2="245" color="pink" head-size="15" width="1" class="z-100" seed="70" />
</div>

<style>
  .slidev-vclick-hidden {
    display: none;
  }
</style>

<!--
Commands are likewise straightforward to implement at the most basic level, providing us with a request / response pipeline to a single handler.

[click] We simply call `ExecuteAsync()` on our command [click], which will invoke the handler, and optionally return the result. [click]

We can also call `AddError` [click] from a command handler to append to the error context, which will add the error to any others raised by other commands or the endpoint itself.

[click] Commands also give us the benefit of a middleware-like pipeline which function just about the same as pipeline behaviours in MediatR.

[click] Using a middleware here simply requires us to invoke the `next()` delegate to execute our command handler, with whatever code we want to run before [click] and after [click] the command is handled.
-->

---

<h1>FastEndpoints</h1>
<h2>Job queues</h2>

<ul class="content">
  <li>Allows for background processing of commands</li>
  <v-clicks>
    <li>Configurable parallelism, maximum execution time and per-job delayed start and expiry</li>
    <li>Per the functionality of commands, jobs can also return a result</li>
    <li>Job execution progress can also be tracked</li>
    <li>Designed to be durable, job queues require that jobs are persisted; including any values returned as part of the job execution</li>
  </v-clicks>
</ul>

<!--
Coming to some of the spicier offerings, FastEndpoints also gives a way to invoke these same commands as background jobs.

[click] We have control over the degree of parallelism, maximum execution times, delayed starts and expiries.

[click] Given that these jobs are essentially just commands under the hood, they can still return a result if required [click], and we can also track the progress of these jobs.

[click] While it seems like we can just easily throw our existing commands into a job queue, these jobs _are_ designed to be durable, which means there's a bit more setup involved.
-->


---

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
