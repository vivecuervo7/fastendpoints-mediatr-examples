<h2>Data</h2>

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
              <li data-id="models"><span><CsharpIcon />Models.cs</span></li>
            </ul>
        </li>
      </ul>
    </li>
  </ul>

````md magic-move { at: 1, maxHeight: '450px' }
```csharp
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

  <FancyArrow v-click="2" x1="550" y1="240" x2="180" y2="148" color="orange" arc="-0.15" head-size="15" width="1" class="z-100" />
</div>

<!--
CLICK IMMEDIATELY [click]

Most examples also make use of a separate `Data` file to house any data access or manipulation.

[click]

While there's likely far less value in moving this logic around if we're making us of a repository pattern, it can be useful for moving any large queries out of our handler.

Again, while it's not going to appeal to everyone, this does seem to be the common approach &mdash; and in practice it does give us some nice, expressive endpoints without needing us to move code too far away from the endpoint itself.
-->
