<h1>FastEndpoints</h1>
<h2>Remote Command Bus</h2>

<ul class="content">
  <li>Allows for handling commands on a separate server</li>
  <v-clicks>
    <li>Uses the existing <strong>ICommand</strong> and <strong>ICommandHandler</strong> interfaces, just requiring them to be registered as remote procedures — no need for .proto files</li>
    <li>A little more hands-on to set up, requiring individual registration</li>
  </v-clicks>
</ul>

<!--
Sitting on top of gRPC for .NET, we can also easily allow for separate servers to handle our commands.

Now, I've never really had to use gRPC at all, mostly just knowing that it was a thing out there.

[click] However it's made pretty easy easy for us, with FastEndpoints wrapping the implementation under, once again, our commands!

[click] There is a little more setup required however, with each remote procedure needing to be registered individually.
-->

---

<h1>FastEndpoints</h1>
<h2>Remote Command Bus</h2>

<v-drag pos="52,176,400,_">
<div class="box" data-id="client-endpoint">

```csharp {all|none|all}{at:1}
class Endpoint<TRequest>
```
<hr/>

```csharp {all|2|all}{at:1}
var command = new ExampleCommand();
var result = await command.RemoteExecuteAsync();
```
</div>
</v-drag>

<v-drag pos="52,360,400,_">
<div class="box" data-id="client-program" v-click="2">

```csharp
Program.cs
```
<hr/>

```csharp
app.MapRemote(
    "http://localhost:6000",
    c => c.Register<ExampleCommand, int>()
);
```
</div>
</v-drag>

<v-drag pos="530,176,400,_">
<div class="box border-slate-700 bg-gray-900" data-id="server-handler" v-click="3">

```csharp
class Handler : ICommandHandler<ExampleCommand, int>
```
<hr/>

```csharp
Task<int> ExecuteAsync(
    ExampleCommand command,
    CancellationToken ct);
```
</div>
</v-drag>

<v-drag pos="530,360,400,_">
<div class="box border-slate-700 bg-gray-900" data-id="server-program" v-click="3">

```csharp
Program.cs
```
<hr/>

```csharp
app.MapHandlers(h =>
{
    h.Register<ExampleCommand, Handler, int>()
});
```
</div>
</v-drag>

<FancyArrow v-click="2" q1="[data-id=client-endpoint]" q2="[data-id=client-program]" pos1="bottom" pos2="top" color="pink" arc="-0.1" head-size="15" class="z-100" />

<FancyArrow v-click="3" q1="[data-id=client-program]" q2="[data-id=server-program]" pos1="right" pos2="left" color="pink" arc="-0.1" head-size="15" class="z-100" />

<FancyArrow v-click="3" q1="[data-id=server-program]" q2="[data-id=server-handler]" pos1="top" pos2="bottom" color="pink" arc="-0.1" head-size="15" class="z-100" />

<!--
Not wanting to go into too much detail here, as we're starting to get into the very problem-specific areas that these features address, but to cover this at a high level at least, we start with once again, our command.

[click] And, once again all we need to do is change our method call, this time to `RemoteExecuteAsync`.

We do need to tell FastEndpoints where to find the handler, which we do in our `Program.cs` file. [click]

And over on the remote server, we need to register the handler for that command. [click]

At a very high level, very simple to get going if this behaviour is required.

Assuming we have the server up and running, once registered, we can treat it almost like any other command in our codebase.
-->
