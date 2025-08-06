<h2>Entity Mapping</h2>

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
              <li data-id="mapper" v-mark.circle="{ at: 1, color: 'orange', iterations: 1, animationDuration: 350 }"><span><CsharpIcon />Mapper.cs</span></li>
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
```csharp {all|3-11|13-21|all}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request request)
    {
        return new User
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
        };
    }

    public override Response FromEntity(User user)
    {
        return new Response
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
}
```
```csharp {all}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request request)
    {
        return new User();
    }

    public override Response FromEntity(User user)
    {
        return new Response();
    }
}
```
```csharp {3,18}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request request)
    {
        return new User();
    }

    public override Response FromEntity(User user)
    {
        return new Response();
    }
}

public class Endpoint(AppDbContext db) : EndpointWithMapper<Request, Mapper>
{
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = Map.ToEntity(req);

        db.Users.Add(user);
        await db.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}
```
```csharp {8,19}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request request)
    {
        return new User();
    }

    public override Response FromEntity(User user)
    {
        return new Response();
    }
}

public class Endpoint : EndpointWithoutRequest<Response, Mapper>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = new User();
        var response = Map.FromEntity(user);
        await SendOkAsync(response, ct);
    }
}
```
```csharp {19}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request request)
    {
        return new User();
    }

    public override Response FromEntity(User user)
    {
        return new Response();
    }
}

public class Endpoint : EndpointWithoutRequest<Response, Mapper>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = new User();
        await SendMapped(user, ct: ct);
    }
}
```
```csharp {19}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request request)
    {
        return new User();
    }

    public override Response FromEntity(User user)
    {
        return new Response();
    }
}

public class Endpoint : EndpointWithoutRequest<Response, Mapper>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = new User();
        await SendMappedAsync(user, ct: ct);
    }
}
```
```csharp {3,8,19}
public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntityAsync(Request request)
    {
        return new User();
    }

    public override Response FromEntityAsync(User user)
    {
        return new Response();
    }
}

public class Endpoint : EndpointWithoutRequest<Response, Mapper>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var user = new User();
        await SendMappedAsync(user, ct: ct);
    }
}
```
````
</div>

<!--
The last thing we'll cover in terms of a basic endpoint are the wrappers that FastEndpoints gives us around mapping between our entities and their request or response DTOs.

[click] A `Mapper` file is often introduced, which holds some code that simply maps to [click] and from [click] our entity. [click]

I'll shrink those down to give us some extra room to work with. [click]

In the case of our request to entity mapping [click], it gives us the ability to simply call `ToEntity` to convert our request into the target entity.

For response mapping [click], we simply do the inverse of this, and call `FromEntity`.

FastEndpoints also gives us a `SendMapped` method [click] that we can use to return the mapped response DTO.

I've found this can be a little annoying though, as there's both sync and async mapping methods, and depending on whether you call `SendMapped` [click] or `SendMappedAsync` [click], you need to have overridden the correct methods.
-->
