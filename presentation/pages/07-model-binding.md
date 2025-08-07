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
              <li data-id="models" v-mark.highlight="{ at: 1, color: '#034A71', seed: 6, iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Models.cs</span></li>
            </ul>
        </li>
      </ul>
    </li>
  </ul>

<div class="view-transition-models">

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
```csharp
public class Request
{
    public int Id { get; set; }
}
```
````
</div>

<div class="fixed left-[283px] top-[170px] font-serif text-gray-300">
  <div v-click="3" class="mt-8 ml-2">
    <p>Binding order</p>
    <ul class="text-xs font-light text-gray-400">
      <li v-mark.blue.box="9">JSON body</li>
      <li>Form fields</li>
      <li v-mark.yellow.box="8">Route parameters</li>
      <li>Query parameters</li>
      <li>User claims <span class="font-thin text-gray-500">(if property has the <span class="font-light">[FromClaim]</span> attribute)</span></li>
      <li>HTTP headers <span class="font-thin text-gray-500">(if property has the <span class="font-light">[FromHeader]</span> attribute)</span></li>
      <li>Permissions <span class="font-thin text-gray-500">(if property has the <span class="font-light">[HasPermission]</span> attribute)</span></li>
    </ul>
  </div>
  </div>


  <v-drag pos="694,182,113,_">
    <div v-click="8" class="floating-label font-mono text-left" data-id="request-dto">
      <p class="text-yellow-400">POST:&nbsp;/users/2</p>
    </div>
  </v-drag>

  <v-drag pos="696,225,112,_">
    <div v-click="8" class="floating-label text-left" data-id="request-dto">
      <pre class="leading-4 text-xs">
<span v-click="9" class="text-[#60A5FA]">{</span>
<span v-click="9" class="text-[#60A5FA]">   Id: 1,</span>
<span v-click="9" class="text-[#60A5FA]">}</span>
      </pre>
    </div>
  </v-drag>

  <FancyArrow v-click="10" x1="690" y1="220" x2="420" y2="310" color="yellow" arc="-0.05" head-size="15" width="1" class="z-100" />

  <FancyArrow v-click="[4,5]" x1="240" y1="253" x2="280" y2="253" color="orange" arc="-0.05" head-size="15" width="1" headSize="15" class="z-100" />
  <FancyArrow v-click="[5,6]" x1="240" y1="284" x2="280" y2="284" color="orange" arc="-0.05" head-size="15" width="1" headSize="15" class="z-100" />
  <FancyArrow v-click="[6,7]" x1="240" y1="315" x2="280" y2="315" color="orange" arc="-0.05" head-size="15" width="1" headSize="15" class="z-100" />
</div>

<!--
So, our endpoint is going to be supplied with a fully populated request DTO, with the property values having been automatically bound from the incoming request.

Focusing on our `Models.cs` file [click], this will typically contain both our `Request` and `Response` objects.

We'll focus on the `Request` object in particular [click], as the `Response` is just a stock-standard DTO &mdash; we're just newing that up and returning it in our handler.

The exact order of sources that can populate these properties are as can be seen here. [click]

As a request moves through the list of binding sources [click] [click] [click] [click], we essentially take the value from the last in the list that matches &mdash; with a slight catch for the last three in that they need explicit attributes on the property before we can bind from that source.

As a simple example, given a POST request to `users/2` [click], with a body that specifies a _different_ `Id`, [click] we'll use the value from the route parameter [click] instead of that from the JSON body.
-->
