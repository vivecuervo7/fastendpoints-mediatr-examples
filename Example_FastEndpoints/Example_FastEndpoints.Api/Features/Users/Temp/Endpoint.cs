using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.Users.Temp;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/users/{id:int}");
        Options(x => x.RequireCors(p => p.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var response = new Response { Id = req.Id, Name = "Test" };
        await SendOkAsync(response, ct);
    }
}
