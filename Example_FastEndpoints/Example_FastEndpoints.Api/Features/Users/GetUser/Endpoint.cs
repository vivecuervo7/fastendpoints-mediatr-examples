using Example_FastEndpoints.Infrastructure;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class Endpoint(AppDbContext db) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/users/{Id}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await db.Users.Where(u => u.Id == req.Id).FirstOrDefaultAsync(ct);

        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var response = new Response
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };

        await SendAsync(response, cancellation: ct);
    }
}
