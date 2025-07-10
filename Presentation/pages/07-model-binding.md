<h2>Model binding</h2>

<div class="endpoint-structure mt-4">
  <ul class="files">
    <li class="view-transition-files">
      <span><ProjectIcon />Api</span>
      <ul>
        <li>
          <span><FolderIcon />...</span>
            <ul>
              <li data-id="data"><span><CsharpIcon />Data.cs</span></li>
              <li data-id="endpoint"><span><CsharpIcon />Endpoint.cs</span></li>
              <li data-id="mapper"><span><CsharpIcon />Mapper.cs</span></li>
              <li data-id="models" v-mark.circle="{ seed: 1, at: 1, color: 'orange', iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Models.cs</span></li>
            </ul>
        </li>
      </ul>
    </li>
  </ul>

<div>
````md magic-move { at: 1, maxHeight: '450px' }
```csharp
‎
```
```csharp {all|1-4}
public class Request
{
    public int Id { get; set; }
}

public class Response
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
```
```csharp {all|1-4}
public class Request
{
    public int Id { get; set; }
}
```
````

  <div v-click="4" class="mt-8 ml-2">
    <p>Binding order</p>
    <ul class="text-xs font-light">
      <li>JSON body</li>
      <li>Form fields</li>
      <li>Route parameters</li>
      <li>Query parameters</li>
      <li>User claims <span class="font-thin">(if property has the <span class="font-light">[FromClaim]</span> attribute)</span></li>
      <li>HTTP headers <span class="font-thin">(if property has the <span class="font-light">[FromHeader]</span> attribute)</span></li>
      <li>Permissions <span class="font-thin">(if property has the <span class="font-light">[HasPermission]</span> attribute)</span></li>
    </ul>
  </div>
  </div>


  <v-drag pos="694,182,113,_">
    <div v-click="5" class="floating-label text-left" data-id="request-dto">
      <p class="text-pink-500">POST: /users/1</p>
    </div>
  </v-drag>

  <v-drag pos="696,225,112,_">
    <div v-click="5" class="floating-label text-left" data-id="request-dto">
      <pre class="leading-4 text-xs">
<span class="text-yellow-500">{</span>
<span class="text-sky-500">  Id: 2,</span>
<span class="text-yellow-500">}</span>
      </pre>
    </div>
  </v-drag>

  <FancyArrow v-click="6" x1="830" y1="300" q2="[data-id=request-dto]" pos2="right" color="orange" arc="-0.5" head-size="20" class="z-100" />
</div>

<!--
This is now a good time to talk about model binding.

[click]

Focusing on our `Models.cs` file, this will typically contain both our `Request` and `Response` objects.

[click]

We'll focus on the `Request` object in particular, as the `Response` is just a stock-standard DTO &mdash; we're just newing that up and returning it in our handler.

[click]

So, our endpoint is going to be supplied with a fully populated request DTO, with the property values having been automatically bound from the incoming request.

The exact order of sources that populate these properties are as can be seen here.

[click]

As a request moves through the list of binding sources, we essentially take the value from the last in the list that matches &mdash; with a slight catch for the last three in that they need explicit attributes on the property before we can bind from that source.

[click]

As a simple example, given a POST request to `users/1`, with a body that specifies a _different_ `Id`, [click] we'll use the value from the route parameter.
-->
