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

<div class="box w-[50%]" data-id="endpoint">
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
await PublishAsync(_event, cancellation: ct)
```
```csharp
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForAll, ct)
```
```csharp
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForAny, ct)
```
```csharp {all|all}
var _event = new ExampleEvent();
await PublishAsync(_event, Mode.WaitForNone, ct)
```
```csharp
var _event = new ExampleEvent();
await _event.PublishAsync(Mode.WaitForNone, ct)
```
````
</div>

<FancyArrow v-click="[3,6]" x1="330" y1="320" x2="310" y2="280" color="orange" arc="0.15" head-size="15" width="1" class="z-100" seed="1" />

  <v-drag pos="568,352,344,_">
    <div class="box" data-id="first" v-click="2">
```csharp
class Handler_1 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct)
```
    </div>
  </v-drag>

  <FancyArrow v-click="2" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="gray" head-size="15" width="1" class="z-100" seed="1" />
  <FancyArrow v-click="[2,5]" q1="[data-id=endpoint]" q2="[data-id=first]" pos1="bottom-right" pos2="top-left" color="pink" head-size="15" width="1" class="z-100" seed="1" />

  <v-drag pos="608,204,344,_">
    <div class="box" data-id="second" v-click="3">
```csharp
class Handler_2 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct)
```
    </div>
  </v-drag>

  <FancyArrow v-click="3" q1="[data-id=endpoint]" q2="[data-id=second]" pos1="right" pos2="left" color="gray" head-size="15" width="1" class="z-100" seed="2" />
  <FancyArrow v-click="[3,4]" q1="[data-id=endpoint]" q2="[data-id=second]" pos1="right" pos2="left" color="pink" head-size="15" width="1" class="z-100" seed="2" />

  <v-drag pos="133,412,344,_">
    <div class="box" data-id="third" v-click="3">
```csharp
class Handler_3 : IEventHandler<ExampleEvent>
```
      <hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct)
```
    </div>
  </v-drag>

  <FancyArrow v-click="3" q1="[data-id=endpoint]" q2="[data-id=third]" pos1="bottom" pos2="top" color="gray" head-size="15" width="1" class="z-100" seed="3" />
  <FancyArrow v-click="[3,4]" q1="[data-id=endpoint]" q2="[data-id=third]" pos1="bottom" pos2="top" color="pink" head-size="15" width="1" class="z-100" seed="3" />
</div>

<!--
Events are pretty straightforward — create an event inside an `Endpoint` and publish it with `PublishAsync` [click], and any event handlers with that event provided as its type parameter [click] will be invoked.

We can wait for all [click], wait for any [click], or we can wait for none [click] of these events to complete. [click]

Events can also be invoked from outside of an endpoint if required [click], by having our event class implement `IEvent`, which exposes a `PublishAsync()` method on the event itself.

All up, very similar to MediatR's notifications.
-->
