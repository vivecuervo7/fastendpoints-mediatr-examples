using Example_FastEndpoints.Api.Extensions;
using Example_FastEndpoints.Infrastructure;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class EndpointWithMvcProblemDetails(AppDbContext db) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/users/{Id}/problemdetails/mvc");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await db.Users.Where(u => u.Id == req.Id).FirstOrDefaultAsync(ct);

        if (user == null)
        {
            // While this could be done here directly, using extension methods makes this more reusable. This
            // is probably the nicest balance between FastEndpoint's succinct syntax and providing useful and
            // expected problem details.

            await this.SendNotFoundProblemDetails("User not found", ct);
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
