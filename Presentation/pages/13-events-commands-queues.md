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

[click]

Events are essentially a one-to-many fire-and-forget, while commands [click] have a one-to-one relationship with handlers, and may return a result.

[click]

We also have the ability to queue up commands to be run in the background &mdash; useful for long-running tasks where we don't want to block a user's interaction with a web page.
-->

---

<h1>FastEndpoints</h1>
<h2>Events</h2>

<div class="content">

<v-drag pos="52,176,350,_">
  <div class="box" data-id="endpoint">
```csharp
class Endpoint<TRequest>
```
  <hr/>
````md magic-move
```csharp
var _event = new ExampleEvent();
```
```csharp {all|all}
var _event = new ExampleEvent();
await PublishAsync(_event, cancellation: ct);
```
```csharp
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForAny, ct);
```
```csharp
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForAll, ct);
```
```csharp
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForNone, ct);
```
```csharp
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
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
    </div>
  </v-drag>

  <FancyArrow v-click="2" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="gray" head-size="15" width="1" class="z-100" seed="1" />
  <FancyArrow v-click="[3,5]" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="pink" head-size="15" width="1" class="z-100" seed="1" />

  <v-drag pos="608,204,350,_">
    <div class="box" data-id="second" v-click="3">
```csharp
class Handler_2 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
    </div>
  </v-drag>

  <FancyArrow v-click="3" q1="[data-id=endpoint]" q2="[data-id=second]" pos1="right" pos2="left" color="gray" head-size="15" width="1" class="z-100" seed="2" />
  <FancyArrow v-click="[4,5]" q1="[data-id=endpoint]" q2="[data-id=second]" pos1="right" pos2="left" color="pink" head-size="15" width="1" class="z-100" seed="2" />

  <v-drag pos="133,412,350,_">
    <div class="box" data-id="third" v-click="3">
```csharp
class Handler_3 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
    </div>
  </v-drag>

  <FancyArrow v-click="3" q1="[data-id=endpoint]" q2="[data-id=third]" pos1="bottom" pos2="top" color="gray" head-size="15" width="1" class="z-100" seed="3" />
  <FancyArrow v-click="[4,5]" q1="[data-id=endpoint]" q2="[data-id=third]" pos1="bottom" pos2="top" color="pink" head-size="15" width="1" class="z-100" seed="3" />
</div>

<!--
Events are pretty straightforward — create an event inside an `Endpoint` and publish it with `PublishAsync` [click], and any event handlers with that event provided as its type parameter will be invoked. [click]

We can wait for any of our handlers [click], wait for all of them [click], or we can wait for none [click].

Events can also be invoked from outside of an endpoint if required [click], by having our event class implement `IEvent`, which exposes a `PublishAsync()` method on the event itself.

All up, very similar to MediatR's notifications.
-->

---

<h1>FastEndpoints</h1>
<h2>Commands</h2>

<div class="content">
  <v-drag pos="52,176,315,_">
    <div class="box" data-id="command-endpoint">
```csharp
class Endpoint<TRequest>
```
      <hr/>
```csharp
var command = new ExampleCommand();
var result = await command.ExecuteAsync(ct);
```
    </div>
  </v-drag>

  <v-drag pos="491,176,390,_">
    <div class="box" data-id="command-handler" v-click="1">
```csharp
class Handler : ICommandHandler<ExampleCommand, int>
```
      <hr/>
```csharp
Task<int> ExecuteAsync(
    ExampleCommand command,
    CancellationToken ct);
```
<div v-click="2" class="v-click-foo">
  <hr/>
```csharp
AddError("Error message");
```
</div>
    </div>
  </v-drag>

  <FancyArrow v-click="1" q1="[data-id=command-endpoint]" pos1="right" x2="493" y2="245" color="pink" head-size="15" width="1" class="z-100" />
</div>

<style>
  .slidev-vclick-hidden {
    display: none;
  }
</style>

<!--
Commands are similarly straightforward at the most basic level, providing us with a request / response pipeline to a single handler.

[click]

We simply call `ExecuteAsync()` on our command, which will invoke the handler and return the result.

[click]

We can also call `AddError` from a command handler to append to the error context, which will be aggregated along with any other errors raised by other commands or the endpoint itself.
-->

---

<h1>FastEndpoints</h1>
<h2>Commands</h2>

<div class="content">
  <v-drag pos="52,176,315,_">
    <div class="box" data-id="middleware-endpoint">
```csharp
class Endpoint<TRequest>
```
      <hr/>
```csharp
var command = new ExampleCommand();
var result = await command.ExecuteAsync(ct);
```
    </div>
  </v-drag>

  <v-drag pos="491,176,390,_">
    <div class="box" data-id="middleware">
```csharp
class Middleware
    : ICommandMiddleware<ExampleCommand, int>
```
      <hr/>
```csharp
Task<int> ExecuteAsync(
    ExampleCommand command,
    CommandDelegate<int> next,
    CancellationToken ct);
```
<hr/>
<div data-id="middleware-before">
```csharp
// Code to execute before command
```
</div>
```csharp
var result = await next();  // Invoke handler
```
```csharp
// Code to execute after command
```
<div data-id="middleware-after">
```csharp
return result;
```
</div>
    </div>
  </v-drag>

  <FancyArrow q1="[data-id=middleware-endpoint]" pos1="right" x2="493" y2="260" color="pink" head-size="15" width="1" class="z-100" />
</div>

<!--
Commands also give us the benefit of a middleware-like pipeline which function just about the same as pipeline behaviours in MediatR.

Using a middleware here simple requires us to invoke the `next()` delegate, with whatever code we wish to execute before and after the command handler.
-->

---

<h1>FastEndpoints</h1>
<h2>Job queues</h2>

<div class="content">
  <v-drag pos="52,176,350,_">
    <div class="box">
```csharp
class Endpoint<TRequest>
```
      <hr/>
````md magic-move
```csharp
var command = new ExampleCommand();
var result = await command.ExecuteAsync(ct);
```
```csharp
var command = new ExampleCommand();
var result = await command.QueueJobAsync(ct: ct);
```
````
    </div>
  </v-drag>

</div>

<!--
Leaning into commands more heavily and getting into the really interesting offerings.

Job queues are a fantastic piece of functionality, giving us an easy way to spin up background jobs — useful for long-running tasks where we don’t want to block a user’s interaction with a web page, for example.

The jobs themselves are use the same ICommand interface — unless we want to hook into progress tracking, in which case we must use a different interface provided by FastEndpoints.

While it is a little annoying to have this decision made for us, jobs are designed to be durable and as such require a persistence layer of sorts.

While a little boilerplate needs to be introduced to support this, it is largely copying and pasting a couple of files from the documentation, and we very quickly have a nice way to handle potentially long-running background operations asynchronously.

Outside of bringing in the boilerplate code, we simply call QueueJobAsync() on the command instead of ExecuteAsync() to queue the command for background execution.

This command in particular implements job tracking, so it uses the ITrackableJob interface, and the handler on the right sets the total steps before looping through and incrementing the steps over time.

Since the endpoint that starts the job returns a tracking ID, <CLICK> we can use that to cancel the job at any point.

Assuming we don’t do that however, we can query the status of the job, allowing us to provide the caller with a progress update, or simply sending back the result <CLICK>.

Very handy, with just a small amount of boilerplate code required.
-->
