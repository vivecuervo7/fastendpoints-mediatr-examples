<h1>FastEndpoints</h1>
<h2>Remote Event Queues</h2>

<ul class="content">
  <li>Similar to commands, uses the existing <strong>IEvent</strong> and <strong>IEventHandler</strong> interfaces</li>
  <v-clicks>
    <li>Server may broadcast events, or configured as an event broker to relay events</li>
    <li>Can optionally be persisted with an approach similar to that for durable job queues</li>
  </v-clicks>
</ul>

<!--
We can also handle events on a separate server as well, this time using the same `IEvent` and `IEventHandler` interfaces that we use for local events.

[click] By default, only the server can broadcast events, but can be configured to act as an event broker, relaying events to all subscribers, or in a round-robin format for distributed workloads.

[click] Events are handled in-memory by default, but we can apply a pattern similar to what we saw for the durable background jobs.

Although at this point, it's probably worth considering using a dedicated message broker.
-->

---

<h1>FastEndpoints</h1>
<h2>Remote Event Queues</h2>

<v-drag pos="52,176,415,_">
<div class="box border-slate-700 bg-gray-900" data-id="server-program">

```csharp {all|none|none|none|none|none|none|none|all}{at:1}
Program.cs
```
<hr/>

````md magic-move {at:1}
```csharp {all|3|none|none|none}{at:1}
app.MapHandlers(h =>
{
    h.RegisterEventHub<ExampleEvent>();
});
```
```csharp {3|none|none}{at:1}
app.MapHandlers(h =>
{
    h.RegisterEventHub<ExampleEvent>(HubMode.EventBroker);
});
```
````

<div v-click="[2,5]">
<hr/>

```csharp {all|none|all|none}{at:1}
var _event = new ExampleEvent();
await _event.Broadcast();
```
</div>
</div>
</v-drag>

<v-drag pos="52,360,400,_">
<div class="box" data-id="client-publish" v-click="7">

```csharp
class Endpoint<TRequest>
```
<hr/>

```csharp
var _event = new ExampleEvent();
await _event.RemotePublishAsync();
```
</div>
</v-drag>

<v-drag pos="550,156,400,186">
<div class="box" v-click="4">
```csharp
class Handler : IEventHandler<ExampleEvent>
```
<hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
</div>
</v-drag>

<v-drag pos="540,166,400,186">
<div class="box" v-click="4">
```csharp
class Handler : IEventHandler<ExampleEvent>
```
<hr/>
```csharp
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
</div>
</v-drag>

<v-drag pos="530,176,400,186">
<div class="box" data-id="client-handler" v-click="4">

```csharp {all|all|none|none|none|none|all}{at:4}
class Handler : IEventHandler<ExampleEvent>
```
<hr/>

```csharp {all|all|none|none|none|none|all}{at:4}
HandleAsync(ExampleEvent ev, CancellationToken ct);
```
</div>
</v-drag>

<v-drag pos="530,360,400,_">
<div class="box" data-id="client-program" v-click="3">

```csharp {all|all|all|none|none|none|all}{at:3}
Program.cs
```
<hr/>

````md magic-move {at:3}
```csharp {all|all|all|none}{at:3}
app.MapRemote(
    "http://localhost:6000",
    c => c.Subscribe<ExampleEvent, Handler>();
);
```
```csharp {3|none}{at:1}
app.MapRemote(
    "http://localhost:6000",
    c => c.RegisterEvent<ExampleEvent>();
);
```
````

</div>
</v-drag>

<FancyArrow v-click="[3,5]" x1="250" y1="378" x2="533" y2="440" pos2="left" color="pink" arc="-0.15" head-size="15" class="z-100" />

<FancyArrow v-click="[4,5]" x1="730" y1="363" x2="730" y2="274" pos2="bottom" color="pink" arc="-0.1" head-size="15" class="z-100" />

<FancyArrow v-click="8" x1="250" y1="363" x2="255" y2="322" color="pink" arc="0.1" head-size="15" class="z-100" />

<FancyArrow v-click="9" x1="463" y1="220" x2="533" y2="220" color="pink" arc="0.1" head-size="15" class="z-100" />

<style>
  .slidev-vclick-hidden {
    display: none;
  }
</style>

<!--
Again, just looking at this at a high level, so we won't go into the persistence side of things.

So, over on our server's `Program.cs` [click], we register the event hub for our `ExampleEvent`.

To actually send an event out to any listeners [click], we need to create an instance of that event, and then call `Broadcast` on it.

That will notify any subscribers of that event [click], which are registered in each client's `Program.cs`.

[click] Once that notification has been raised, then any handlers registered for that event are invoked.

_[[pause]]_

Registering the server as an event broker is also quite easy to set up.

Coming back to where we registered our event hub [click], we simply need it to tell to start in event broker mode.

This essentially means that now both the server and connected clients can issue events.

[click] And to achieve that, first we need to tell our client's `Program.cs` to register the event as a remote procedure, [click] and then we can call `RemotePublishAsync` on the event somewhere in our client.

[click] This will hit the event hub [click], which then sends it out to all of the subscribed clients.
-->
