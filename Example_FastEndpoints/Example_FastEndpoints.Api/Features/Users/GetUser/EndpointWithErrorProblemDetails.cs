using Example_FastEndpoints.Infrastructure;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class EndpointWithErrorProblemDetails(AppDbContext db) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/users/{Id}/problemdetails/senderror");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await db.Users.Where(u => u.Id == req.Id).FirstOrDefaultAsync(ct);

        if (user == null)
        {
            // Not the nicest way to get a ProblemDetails, as this is overloading FastEndpoint's
            // validation failures logic, which means we might be sending validation errors
            // with a 404 status code. Example: Uncomment the line below and review the output.
            //
            // AddError(x => x.Id, "Example: Invalid user ID");

            AddError("User not found");
            await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
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
