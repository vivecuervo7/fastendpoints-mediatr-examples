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

This allows for what is a very simple starting point to organically grow into a solution that more reminiscent of a typical Mediator-based solution; or, perhaps we just want to extract some common logic without necessarily wrapping it a service.

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

````md magic-move { at: 1, maxHeight: '450px' }
```csharp {all|5}
public class Endpoint : EndpointWithoutRequest
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        await PublishAsync(new ExampleEvent(), cancellation: ct);
        await SendOkAsync(ct);
    }
}
```
```csharp {5|5}
public class Endpoint : EndpointWithoutRequest
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        await PublishAsync(new ExampleEvent(), Mode.WaitForAll, ct);
        await SendOkAsync(ct);
    }
}
```
```csharp {5}
public class Endpoint : EndpointWithoutRequest
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        await new ExampleEvent().PublishAsync(Mode.WaitForAll, ct);
        await SendOkAsync(ct);
    }
}
```
````

  <v-drag pos="526,351,403,_">
    <div v-click="1" v-mark.blue.box="{ at: 1, strokeWidth: 1, iterations: 1 }" class="box2 font-serif " data-id="first">
```csharp
public class FirstEventHandler : IEventHandler<ExampleEvent>
{
    public Task HandleAsync(ExampleEvent ev, CancellationToken ct)
    {
        return Task.CompletedTask;
    }
}
```
    </div>
  </v-drag>

  <FancyArrow v-click="1" x1="445" y1="265" q2="[data-id=first]" pos2="top-left" color="blue" head-size="15" width="1" class="z-100" />

  <v-drag pos="547,198,403,_">
    <div v-click="3" v-mark.blue.box="{ at: 3, strokeWidth: 1, iterations: 1 }" class="box2 font-serif " data-id="second">
```csharp
public class SecondEventHandler : IEventHandler<ExampleEvent>
{
    public Task HandleAsync(ExampleEvent ev, CancellationToken ct)
    {
        return Task.CompletedTask;
    }
}
```
    </div>
  </v-drag>

  <FancyArrow v-click="3" x1="465" y1="250" q2="[data-id=second]" pos2="left" color="blue" head-size="15" width="1" class="z-100" />

  <v-drag pos="88,373,403,_">
    <div v-click="3" v-mark.blue.box="{ at: 3, strokeWidth: 1, iterations: 1 }" class="box2 font-serif " data-id="third">
```csharp
public class ThirdEventHandler : IEventHandler<ExampleEvent>
{
    public Task HandleAsync(ExampleEvent ev, CancellationToken ct)
    {
        return Task.CompletedTask;
    }
}
```
    </div>
  </v-drag>

  <FancyArrow v-click="3" x1="340" y1="265" q2="[data-id=third]" pos2="top" color="blue" head-size="15" width="1" class="z-100" />
</div>

<style>
  .box {
    scale: 70%;
  }
</style>

<!--
Events are pretty straightforward [click] — publish an event, and any event handlers with that event provided as its type parameter will be invoked.

[click]

We can wait for all [click], any or none of these events to complete.

Events can also be invoked from outside of an endpoint if required [click], by marking the event class as an `IEvent`, which exposes a `PublishAsync()` method on the event itself.
-->
