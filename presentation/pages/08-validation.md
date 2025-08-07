<h2 v-click.hide="9">Validation</h2>
<h2 v-click="[9,12]">Dependency Injection</h2>
<h2 v-click="12">Data</h2>

<div class="endpoint-structure mt-4">
  <ul class="files">
    <li class="view-transition-files">
      <span><ProjectIcon />Api</span>
      <ul>
        <li>
          <span><FolderIcon />...</span>
            <ul>
              <li data-id="data" v-mark.highlight="{ at: 13, color: '#034A71', seed: 6, iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Data.cs</span></li>
              <li data-id="endpoint" v-mark.highlight="{ at: [5,13], color: '#034A71', seed: 6, iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Endpoint.cs</span></li>
              <li data-id="mapper"><span><CsharpIcon />Mapper.cs</span></li>
              <li data-id="models" v-mark.highlight="{ at: [1,5], color: '#034A71', seed: 6, iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Models.cs</span></li>
            </ul>
        </li>
      </ul>
    </li>
  </ul>

````md magic-move { at: 1, maxHeight: '450px' }
```csharp
‎
```
```csharp
public class Request
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
}
```
```csharp {7-14|7|7-14}
public class Request
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).Must(x => x > 0).WithMessage("Id must be a positive integer");
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
```
```csharp
public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            // Invalid request
        }

        await SendNoContentAsync(ct);
    }
}
```
```csharp {6}
public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            // Invalid request
        }

        await SendNoContentAsync(ct);
    }
}
```
```csharp {15}
public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        await SendNoContentAsync(ct);
    }
}
```
```csharp {18}
public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        ThrowIfAnyErrors();

        await SendNoContentAsync(ct);
    }
}
```
```csharp {11}
public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        ThrowIfAnyErrors();

        await SendNoContentAsync(ct);
    }
}
```
```csharp {1}
public class Endpoint(AppDbContext db) : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        ThrowIfAnyErrors();

        await SendNoContentAsync(ct);
    }
}
```
```csharp {11-14}
public class Endpoint(AppDbContext db) : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Config.GetSection("");       // IConfiguration
        Logger.LogInformation("");   // ILogger
        Env.IsDevelopment();         // IWebHostEnvironment

        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        ThrowIfAnyErrors();

        await SendNoContentAsync(ct);
    }
}
```
```csharp {11}
public class Endpoint(AppDbContext db) : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await db.Users.AnyAsync(u => u.Email == req.Email, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        ThrowIfAnyErrors();

        await SendNoContentAsync(ct);
    }
}
```
```csharp {11}
public class Endpoint(AppDbContext db) : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/users/{id:int}");
        DontThrowIfValidationFails();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var emailAlreadyExists = await Data.EmailAlreadyExists(db, req, ct);

        if (emailAlreadyExists)
        {
            AddError("Email is already in use");
        }

        ThrowIfAnyErrors();

        await SendNoContentAsync(ct);
    }
}
```
````

  <FancyArrow v-click="13" x1="550" y1="240" x2="175" y2="145" color="orange" arc="-0.15" head-size="15" width="1" class="z-100" />
</div>

<style>
    h2.slidev-vclick-hidden {
        display: none;
    }
</style>

<!--
Closely related to model binding, we also get validation straight out of the box with FastEndpoints, using FluentValidation rules.

Typically this ends up in our `Models` file. [click] [click], although I'm not a fan of squeezing too many different classes into a single file, and actually do tend to break this one out.

But, we'll stick to what seems to be the most common pattern in the examples floating around the web.

Similar to where we had the option to move our endpoint summary outside of the endpoint file itself [click], we can just pass the endpoint as a type parameter to a class inheriting from `Validator` and we won't need to manually register this with our DI container. [click]

Now, validation failures _will_ be returned automatically upon receiving a request that fails any validation rules specified here.

Which is nice and succinct for the simple cases, but we can build on this for more complex cases where we need to consider business logic.

Coming back to our `Endpoint` class [click], we can tell FastEndpoints to not automatically return a validation failed response by calling `DontThrowIfValidationFails` [click].

Calling `AddError` adds an error to the aggregated list. [click]

This allows us to provide a response that contains _all_ of our errors to save on multiple repeat requests that only discover new errors.

This alone isn't enough to actually return an error.

While FastEndpoints offers us more explicit ways to return such a failure, the easiest way to prevent further execution of our endpoint logic is to simply call `ThrowIfAnyErrors` [click].

This will interrupt our handler execution and send a response with all of our aggregated errors, by default with an overridable 400 status code.

[click] Now, we can see here that we've also introduced the use of a service &mdash; in this case, a `DbContext`.

Injecting this is straightforward [click], just needing to be injected via the constructor.

In addition to any explicitly injected services [click], FastEndpoints automatically resolves some services for us.

Every endpoint, by default, has access to the configuration, a logger and the web host environment.

_[[pause]]_

[click] Most examples also make use of a separate `Data` file to house any data access or manipulation.

[click]

While there's likely far less value in moving this logic around if we're making use of a repository pattern, or we only have fairly small queries, it can be useful for moving any large blocks of code out of our handler.

Again, while it's not going to appeal to everyone, this does seem to be the common approach &mdash; and in practice it does give us a really nice, concise, and expressive endpoint without needing us to move code too far away from the endpoint itself.
-->
