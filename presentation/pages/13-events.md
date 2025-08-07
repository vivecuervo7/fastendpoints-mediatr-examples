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

[click] Events are essentially a 1:many fire-and-forget operation, while commands [click] have a 1:1 relationship with handlers, and may return a result.

[click] We also have the ability to queue up commands to be run in the background &mdash; useful for those long-running tasks where we don't want to block a user's interaction with a web page.
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

  <v-drag pos="568,352,355,_">
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
  <FancyArrow v-click="[2,7]" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="pink" head-size="15" class="z-100" seed="1" />
  <FancyArrow v-click="[5,7]" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="pink" head-size="15" width="5" class="z-100" seed="1" />

  <v-drag pos="608,204,355,_">
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

  <v-drag pos="133,412,355,_">
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
