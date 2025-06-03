---
theme: default
title: FastEndpoints
info: Overview of FastEndpoints features
transition: view-transition
mdc: true
addons:
  - fancy-arrow
fonts:
  serif: Shantell Sans
---

<img src="./images/FE-logo.svg" class="mr-80">
<div class="absolute left-3.5rem bottom-2.5rem">
  Isaac&nbsp;Dedini
</div>

<!--
The last comment block of each slide will be treated as slide notes. It will be visible and editable in Presenter Mode along with the slide. [Read more in the docs](https://sli.dev/guide/syntax.html#notes)
-->

---
layout: statement
---

<div class="text-size-4xl mx-30">
  "FastEndpoints is a developer friendly alternative to Minimal APIs & MVC"
</div>

---
layout: section
---

<div class="text-size-7xl mx-30">
  Why?
</div>

---

<h1>Why?</h1>
<h2>What drove me to FastEndpoints?</h2>

<ul class="content">
  <li>A feeling of over-abstracted code in what were often relatively simple APIs</li>
  <li>Stumbled across FastEndpoints online and started tinkering with it out of curiosity</li>
  <li>FastEndpoints felt easy to use where the typical architecture felt cumbersome</li>
  <li>Commercialisation of MediatR led me to consider FastEndpoints as a genuine alternative</li>
</ul>

<!-- 
Every project I’ve worked on has had roughly the same setup for what is usually a relatively simple API, using MediatR to send and handle commands and requests

Scrolling through YouTube one day, I saw a short video covering a very basic API built with FastEndpoints, and I was intrigued by how clean it looked

I had played with it a little, liked what I had seen, but really it was the recent commercialisation of MediatR which made me sit back and think about whether FastEndpoints might be a genuine alternative the usual project structure
-->

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="370,225,240,240">
  <div class="onion-application onion-circle view-transition-application"></div>
</v-drag>

<v-drag pos="425,280,130,130">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label" data-id="presentation">Presentation</div>
</v-drag>

<v-drag pos="430,245,120,_">
  <div class="onion-label view-transition-application-label" data-id="application">Application</div>
</v-drag>

<v-drag pos="450,330,80,_">
  <div class="onion-label view-transition-domain-label" data-id="domain" v-mark.red.box="9">Domain</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label" data-id="infrastructure">Infrastructure</div>
</v-drag>

<v-drag pos="160,172,112,_">
  <div v-click="1" class="floating-label" data-id="request-dto">Request DTO</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=request-dto]" pos1="top-left" pos2="right" color="orange" arc="-0.05" head-size="20" class="z-100" />

<v-drag pos="114,206,96,_">
  <div v-click="1" class="floating-label" data-id="controller">Controller</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=controller]" pos1="top-left" pos2="right" color="orange" arc="-0.05" head-size="20" class="z-100" />

<v-drag pos="629,177,120,_">
  <div v-click="1" class="floating-label" data-id="response-dto">Response DTO</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=response-dto]" pos1="top-right" pos2="left" color="orange" arc="0.075" head-size="20" class="z-100" />

<v-drag pos="22,327,141,_">
  <div v-click="2" class="floating-label" data-id="query">Query / Command</div>
</v-drag>
<FancyArrow v-click="2" q1="[data-id=application]" q2="[data-id=query]" pos1="left" pos2="top-right" color="orange" arc="-0.15" head-size="20" class="z-100" />

<v-drag pos="192,461,88,_">
  <div v-click="5" class="floating-label" data-id="mediator">MediatR</div>
</v-drag>
<FancyArrow v-click="5" q1="[data-id=application]" q2="[data-id=mediator]" pos1="bottom-left" pos2="top" color="red" arc="-0.25" head-size="20" class="z-100" />

<v-drag pos="803,307,81,_">
  <div v-click="3" class="floating-label" data-id="handler" v-mark.red.box="8">Handler</div>
</v-drag>
<FancyArrow v-click="3" q1="[data-id=application]" q2="[data-id=handler]" pos1="right" pos2="top-left" color="orange" arc="0.1" head-size="20" class="z-100" />
<FancyArrow v-click="4" q1="[data-id=handler]" q2="[data-id=domain]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
<FancyArrow v-click="4" q1="[data-id=handler]" q2="[data-id=infrastructure]" pos1="left" pos2="top-right" color="purple" head-size="20" class="z-100" />

<FancyArrow v-click="2" q1="[data-id=controller]" q2="[data-id=query]" pos1="bottom" pos2="top" color="teal" arc="-0.2" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="5" q1="[data-id=query]" q2="[data-id=mediator]" pos1="bottom" pos2="top-left" color="teal" arc="-0.25" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="6" q1="[data-id=mediator]" q2="[data-id=handler]" pos1="bottom" pos2="bottom" color="red" arc="-0.375" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="7" q1="[data-id=handler]" q2="[data-id=response-dto]" pos1="top" pos2="right" color="teal" arc="-0.25" width="0.5" head-size="20" class="z-100" />

<!--
Referring back to that typical architecture diagram, one of the biggest problems in my opinion

Makes the handler an attractive place to just dump logic

We end up with domain logic littered throughout our handlers
-->

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="380,235,220,220">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label" data-id="presentation">Presentation</div>
</v-drag>

<v-drag pos="430,340,120,_">
  <div class="onion-label view-transition-application-label" data-id="application">Application</div>
</v-drag>

<v-drag pos="450,310,80,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
  <div class="onion-label view-transition-domain-plus">+</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
…and we end up with this big mess in our domain project, with all the application code lumped in there

FastEndpoints allows us to move that application logic into the presentation layer without overloading an already busy controller
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="410,265,160,160">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label">Presentation</div>
  <div class="onion-label view-transition-presentation-plus">+</div>
</v-drag>

<v-drag pos="430,225,120,_">
  <div class="onion-label view-transition-application-label">Application</div>
</v-drag>

<v-drag pos="450,330,80,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
...making it much easier to maintain that clear boundary of the domain layer
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="120,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="210,265,160,160">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="230,195,120,_">
  <div class="onion-label view-transition-presentation-label" v-mark.orange.box="1">Presentation</div>
  <div class="onion-label view-transition-presentation-plus">+</div>
</v-drag>

<v-drag pos="230,225,120,_">
  <div class="onion-label view-transition-application-label" v-mark.purple.box="3">Application</div>
</v-drag>

<v-drag pos="250,330,80,_">
  <div class="onion-label view-transition-domain-label" data-id="domain">Domain</div>
</v-drag>

<v-drag pos="225,470,130,_">
  <div class="onion-label view-transition-infrastructure-label" data-id="infrastructure">Infrastructure</div>
</v-drag>

<v-drag pos="606,167,239,_">
  <div class="box view-transition-endpoint-box">
    <div v-mark.orange.box="2" class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div v-mark.purple.box="4" data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-click at="5">
  <FancyArrow q1="[data-id=handler]" q2="[data-id=domain]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
</v-click>

<v-click at="5">
  <FancyArrow q1="[data-id=handler]" q2="[data-id=infrastructure]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
</v-click>

<!--
…by having only one endpoint per file that also contains the handler code
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="40,175,239,_">
  <div class="box" data-id="ep1">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="260,175,239,_">
  <div class="box" data-id="ep2" v-mark.orange.box="1">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="480,175,239,_">
  <div class="box" data-id="ep3">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="700,175,239,_">
  <div class="box view-transition-endpoint-box" data-id="ep4">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="430,160,112,_">
  <div v-click="1" class="floating-label text-xl color-orange" data-id="request">Request</div>
</v-drag>

<v-drag pos="430,485,112,_">
  <div v-click="1" class="floating-label text-xl color-orange" data-id="response">Response</div>
</v-drag>

<FancyArrow v-click="1" q1="[data-id=request]" q2="[data-id=ep2]" pos1="left" pos2="top" color="orange" arc="-0.15" head-size="20" class="z-100" />
<FancyArrow v-click="1" q1="[data-id=ep2]" q2="[data-id=response]" pos1="bottom" pos2="top-left" color="orange" arc="-0.15" head-size="20" class="z-100" />

<style>
  .box {
    scale: 70%;
  }
</style>

---

<h1>FastEndpoints</h1>
<h2>Horizontal vs. vertical slices</h2>

<div class="files-columns mt-8">
  <div v-click="0">
    <ul class="box files">
      <li>
        <span><ProjectIcon />Api</span>
        <ul>
          <li>
            <span><FolderIcon />Dtos</span>
            <ul>
              <li><span><CsharpIcon />GetUserRequest.cs</span></li>
              <li><span><CsharpIcon />GetUserResponse.cs</span></li>
            </ul>
          </li>
          <li>
            <span><FolderIcon />Controllers</span>
            <ul>
              <li><span><CsharpIcon />UsersController.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Application</span>
        <ul>
          <li>
            <span><FolderIcon />Queries</span>
            <ul>
              <li><span><CsharpIcon />GetUserQuery.cs</span></li>
              <li><span><CsharpIcon />GetUserQueryHandler.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Domain</span>
        <ul>
          <li>
            <span><FolderIcon />Entities</span>
            <ul>
              <li><span><CsharpIcon />User.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Infrastructure</span>
        <ul>
          <li><span><CsharpIcon />AppDbContext.cs</span></li>
        </ul>  
      </li>
    </ul>
    <ul>
      <li>Hard to find or review code</li>
      <li>
        Too many places for code; too many decisions
        <ul>
          <li>Handlers often calling other handlers</li>
          <li>Domain logic present in application layer</li>
        </ul>
      </li>
    </ul>
  </div>

  <div v-click="1" class="relative">
    <div class="bracket">
      <div></div>
      <img src="./images/FE-icon.svg" class="icon">
      <div></div>
    </div>
    <ul class="box files">
      <li class="view-transition-files">
        <span><ProjectIcon />Api</span>
        <ul>
          <li>
            <span><FolderIcon />Features</span>
            <ul>
              <li>
                <span><FolderIcon />Users</span>
                <ul>
                  <li>
                    <span><FolderIcon />GetUser</span>
                    <ul>
                      <li><span><CsharpIcon />Data.cs</span></li>
                      <li><span><CsharpIcon />Endpoint.cs</span></li>
                      <li><span><CsharpIcon />Mapper.cs</span></li>
                      <li><span><CsharpIcon />Models.cs</span></li>
                    </ul>
                  </li>
                </ul>
              </li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Domain</span>
        <ul>
          <li>
            <span><FolderIcon />Entities</span>
            <ul>
              <li><span><CsharpIcon />User.cs</span></li>
            </ul>
          </li>
        </ul>  
      </li>
      <li>
        <span><ProjectIcon />Infrastructure</span>
        <ul>
          <li><span><CsharpIcon />AppDbContext.cs</span></li>
        </ul>  
      </li>
    </ul>
    <ul>
      <li>Easy to find related code</li>
      <li>Reviewing changes doesn't require bouncing around</li>
      <li>Clearer responsibilities between classes</li>
    </ul>
  </div>
</div>

---

<h2>Endpoint structure</h2>

<div class="root mt-4">
  <ul class="files">
    <li class="view-transition-files">
      <span><ProjectIcon />Api</span>
      <ul>
        <li>
          <span><FolderIcon />...</span>
            <ul>
              <li data-id="data"><span><CsharpIcon />Data.cs</span></li>
              <li data-id="endpoint" v-mark.highlight="{ at: 1, color: '#2A3845'}"><span><CsharpIcon />Endpoint.cs</span></li>
              <li data-id="mapper"><span><CsharpIcon />Mapper.cs</span></li>
              <li data-id="models"><span><CsharpIcon />Models.cs</span></li>
            </ul>
        </li>
      </ul>  
    </li>
  </ul>

````md magic-move { at: 2, maxHeight: '450px' }
```csharp
public class Endpoint : EndpointWithoutRequest
{
  
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/users/{id:int}");
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/users/{id:int}", "/user/{id:int}");
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        AllowAnonymous();
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        Summary(s =>
        {
            s.Summary = "Short summary goes here";
            s.Description = "Long description goes here";
            s.Responses[200] = "Ok response description goes here";
            s.Responses[403] = "Forbidden response description goes here";
        });
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        Description(b => b.Produces(403));
    }
}

public class Summary : Summary<Endpoint>
{
    public Summary()
    {
        Summary = "Short summary goes here";
        Description = "Long description goes here";
        Response(200, "Ok response description goes here");
        Response(403, "Forbidden response description goes here");
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        // Handler logic goes here
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendOkAsync(ct);
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendNotFoundAsync(ct);
    }
}
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendForbiddenAsync(ct);
    }
}
```
````
</div>

<style>
  .root {
    margin-right: -40px;
    display: grid;
    grid-template-columns: 1fr 3fr;
    grid-template-rows: 1fr auto;
    height: 100%;

    li {
      width: fit-content;
      padding-right: 2px;
    }
  }

  .runner {
    margin-bottom: 40px;
    grid-column: 1/-1;
  }
</style>

---

<h3>Endpoint structure</h3>

<span class="slide-reload-marker" style="display:none">reload-1748910879302</span>
<ReloadCodeButton />

<div class="editor-runner">

<<< ../Example_FastEndpoints/Example_FastEndpoints.Api/Features/Users/Temp/Endpoint.cs csharp {monaco-write}

::div
```js {monaco-run} {autorun:false}
const url = 'http://localhost:5158/users/1';
const response = await fetch(url);
const isJson = response.headers.get("content-type")?.includes("application/json");
const data = isJson ? await response.json() : await response.text();
console.log(`Status: ${response.status}`);
console.log(`Body: ${JSON.stringify(data)}`);
```
::
</div>
