---
clicksStart: 0
---

<h2>Dependency Injection</h2>

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
```csharp {18|18|11|1}
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
````
</div>

<!--
[click]

[click] Now, we can see here that we've also introduced the use of a service &mdash; in this case, a `DbContext`.

Injecting this is straightforward [click], just needing to be injected via the constructor.

In addition to any explicitly injected services [click], FastEndpoints automatically pre-resolves some services for us.

Every endpoint, by default, has access to configuration, a logger and the web host environment.
-->
