<h2>Validation</h2>

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
              <li data-id="models" v-mark.circle="{ at: 1, color: 'orange', iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Models.cs</span></li>
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
```csharp {7-14}
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
````
</div>

<!--
Closely related to model binding, we also get validation straight out of the box with FastEndpoints, using FluentValidation rules.

[click]

Typically this ends up in our `Models` file, although personally I don't find myself a fan of squeezing too many different classes into a single file, but we'll stick to what seems to be the most common pattern in the examples floating around the web.

[click]

Similar to where we had the option to move our endpoint summary outside of the endpoint file, we can just pass the endpoint as a type parameter to a class inheriting from `Validator` and we won't need to manually register this with our DI container.

Validation failures will be returned automatically upon receiving a request that fails validation.

Nice and succinct for the simpler cases, but we can build on this for more complex cases where we need to consider business logic.
-->

---

<h2>Validation</h2>

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

````md magic-move { at: 1, maxHeight: '450px' }
```csharp
‎
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
        await SendNoContentAsync(ct);
    }
}
```
```csharp {13-16}
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

        await SendNoContentAsync(ct);
    }
}
```
```csharp {18}
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
````
</div>

<!--
TODO: See if we can stop using rough notation for the file highlight, and then we can collapse this into the previous slide for a smoother transition
-->

<!--
[click] Coming back to our `Endpoint` class, we can tell FastEndpoints to not automatically return a validation failed response by calling `DontThrowIfValidationFails` [click].

Calling `AddError` adds an error to the aggregated list [click], so we can provide a response that contains _all_ of our errors to save on multiple repeat requests to discover new errors.

This alone isn't enough to actually return an error, so while FastEndpoints offers us more explicit ways to return such a failure, the easiest way to prevent further execution of our endpoint logic is to simply call `ThrowIfAnyErrors` [click].

This will interrupt our handler execution and send a response with all of our error details, by default with an easily overriden 400 status code.
-->
