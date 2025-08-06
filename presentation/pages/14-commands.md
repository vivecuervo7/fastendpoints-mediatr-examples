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

[click] Commands also give us the benefit of a middleware-like pipeline which functions just about the same as pipeline behaviours in MediatR.

[click] Using a middleware here simply requires us to invoke the `next()` delegate to execute our command handler, with whatever code we want to run before [click] and after [click] the command is handled.
-->
