<h1>FastEndpoints</h1>
<h2>Server Sent Events</h2>

<v-drag pos="52,176,415,_">
<div class="box" data-id="client-publish" v-click="1">

```csharp {all|all|none|none|all}{at:1}
class Endpoint<TRequest>
```
<hr/>

```csharp {all|all|all|none|all}{at:1}
await SendEventStreamAsync("event", GetDataStream(ct), ct);
```

<div v-click="3">
<hr/>

```csharp
async IAsyncEnumerable<object> GetDataStream(
    [EnumeratorCancellation] CancellationToken ct
)
{
    while (!ct.IsCancellationRequested)
    {
        yield return new { Guid = Guid.NewGuid() };
        await Task.Delay(1000);
    }
}
```
</div>
</div>
</v-drag>

<v-drag pos="510,176,415,_">
<div class="box" data-id="client-publish" v-click="4">

```html
<script>
    const sse = new EventSource("http://localhost:5158/sse");
    sse.addEventListener("event", e => console.log(e.data));
</script>
```
<div v-click="5">
<hr/>

```json
{ "guid": "3f6e7c6b-0a8a-4b6b-8a9c-9f6e8e2b9b77" }
{ "guid": "8d3b2e4c-ba7f-4c8f-a8b5-8c0b3d5f9f10" }
{ "guid": "1a2b3c4d-5e6f-7a8b-9c0d-e1f2g3h4i5j6" }
```
</div>
</div>
</v-drag>

<style>
  .slidev-vclick-hidden {
    display: none;
  }
</style>

<!--
Getting close to the end now, I promise!

Server-sent events are another one that FastEndpoints makes easy.

So if we need any _live_ server-to-client communications, we can implement this pretty easily as well. [click]

We use the `SendEventStreamAsync` method to send the event stream to the client [click], and we need to implement our `GetDataStream` method as well.

[click] This is essentially a method that returns an `IAsyncEnumerable` of whatever thing it is we want to send back.

On the front end [click], we just need to create our `EventSource` and start listening for the events...

[click] And, we should start seeing responses flowing back to the client over time.
-->
