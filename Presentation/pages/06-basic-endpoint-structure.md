<h2>Endpoint structure</h2>

<div class="endpoint-structure mt-4">
  <ul class="files">
    <li class="view-transition-files">
      <span><ProjectIcon />Api</span>
      <ul>
        <li>
          <span><FolderIcon />...</span>
            <ul>
              <li data-id="data"><span><CsharpIcon />Data.cs</span></li>
              <li data-id="endpoint" v-mark.circle="{ at: 1, color: 'orange', iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Endpoint.cs</span></li>
              <li data-id="mapper"><span><CsharpIcon />Mapper.cs</span></li>
              <li data-id="models"><span><CsharpIcon />Models.cs</span></li>
            </ul>
        </li>
      </ul>
    </li>
  </ul>

````md magic-move { maxHeight: '450px' }
```csharp
‎
```
```csharp
public class Endpoint : EndpointWithoutRequest
{
  
}
```
```csharp {3-6}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp {5}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/users/{id:int}");
    }
}
```
```csharp {5}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/users/{id:int}", "/user/{id:int}");
    }
}
```
```csharp {6}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        AllowAnonymous();
    }
}
```
```csharp {7}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        AllowAnonymous();
        Description(x => x.Produces(200));
    }
}
```
```csharp {8}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        AllowAnonymous();
        Description(x => x.Produces(200));
        Options(x => x.RequireCors(p => p.AllowAnyOrigin()));
    }
}
```
```csharp {9-15}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        AllowAnonymous();
        Description(x => x.Produces(200));
        Options(x => x.RequireCors(p => p.AllowAnyOrigin()));
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
```csharp {12-21}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        AllowAnonymous();
        Description(x => x.Produces(200));
        Options(x => x.RequireCors(p => p.AllowAnyOrigin()));
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
```csharp {8-11}
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
```csharp {8-12}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(ct);
    }
}
```
```csharp {1,8-14}
public class Endpoint : EndpointWithoutRequest<Ok>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override async Task<Ok> ExecuteAsync(CancellationToken ct)
    {
        var response = TypedResults.Ok();
        return await Task.FromResult(response);
    }
}
```
```csharp {1,8-14|1}
public class Endpoint : EndpointWithoutRequest<Results<Ok, NotFound>>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override async Task<Results<Ok, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        var response = TypedResults.Ok();
        return await Task.FromResult(response);
    }
}
```
```csharp {1}
public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp {1}
public class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp {1}
public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp {1}
public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }
}
```
```csharp {1,8-12}
public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var response = new Response { Id = req.Id };
        await SendOkAsync(response, ct);
    }
}
```
````
</div>

<!--
So, looking at our overall structure, we'll focus on the implementation of a very basic endpoint before we start diving into the other features.

There is some minimal global registration for FastEndpoints that must be done first in our main `Program` file, but we'll skip over that as it's not anything too unexpected.

[click]

At the most basic level, we simply need to create a class which inherits from `EndpointWithoutRequest`.

This is the most basic type of endpoint that FastEndpoints offers, which is used when we have neither a request nor response DTO.

[click]

To configure the endpoint, we must first override the `Configure` method.

Here we can access many of FastEndpoints' helper methods. The example shown here uses the `Get` method to register the route for a HTTP GET method.

[click]

As might be expected, calling `Post` would register a POST route and so forth.

[click]

FastEndpoints also allows us to specify multiple routes for a single endpoint. In this case, a call to either the `user` or `users` route will be handled by this endpoint.

[click]

We can also call other helper methods here, such as `AllowAnonymous`.

FastEndpoints treats all endpoints as secure by default. Endpoints can be globally configured in `Program.cs`, so we _can_ change this, but this is something to be aware of.

[click]

Helper methods are also available to describe the endpoint...

[click]

Or even configure CORS for a specific endpoint.

[click]

We can also enhance Swagger documentation through the `Summary` method...

[click]

And if we want to avoid cluttering up our endpoint, this can be moved to a separate class that inherits from `Summary`, with the endpoint passed to it as a type parameter.

This will be automatically registered to the endpoint, so there's no need to go wiring things up manually.

[click]

Coming back to our basic endpoint, we still need a place to put our handler code.

[click]

We do this by overriding the `HandleAsync` method.

Essentially, given the proposed usage, this is where we would put the code that would otherwise live in our application layer.

Of course, nothing is stopping us from simply passing this off to a mediator pipeline, but this in my mind undermines the value of having this nice little file that contains all of our endpoint's code.

[click]

Marking this as async allows us to return a response by calling one of many helper methods.

In this case, we're calling `SendOkAsync` which returns a response with a 200 status code.

FastEndpoints offers quite a few convenience methods here. Without listing them all, we have options such as `SendNotFoundAsync`, or `SendForbiddenAsync` which do very much what the label says.

Now, the first gotcha that I encountered with FastEndpoints arose here.

The usage of `await` makes it seem that we can execute code _after_ the request has been sent, but in practice I found that this was not the case.

To prevent that from misleading devs, an alternative is available by overriding a different method to `HandleAsync`.

[click]

The `ExecuteAsync` method allows us to specify a strict return type for the method, which brings the implementation a little closer to what we're typically used to.

[click]

As with Minimal API, we can also use the `Results` union type to allow for multiple possible return values.

Ultimately though, this comes down to a trade-off between using those expressive helper methods, and adding guardrails for ourselves.

[click]

We'll focus now on the first line here, where we can see we've passed in the return type.

This is a good segue into the different base classes from which we can inherit when creating a new endpoint.

[click]

We started by inheriting from `EndpointWithoutRequest` with _no_ type parameter. As mentioned earlier, this is used when we have neither a request nor response DTO.

[click]

By passing in a type for our response, we're now describing an endpoint with no request DTO, but _with_ a response DTO.

[click]

Inheriting from the `Endpoint` class expects that we provide a type for the request DTO, and optionally [click], we can pass in a type for the response DTO if we're returning one.

[click]

We can then pass the request into the `HandleAsync` method, and access it in our handler code.
-->