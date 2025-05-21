using Example_FastEndpoints.Infrastructure;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class EndpointWithExplicitProblemDetails(AppDbContext db)
    : Endpoint<Request, Results<Ok<Response>, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/users/{Id}/problemdetails/explicit");
    }

    public override async Task<Results<Ok<Response>, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct
    )
    {
        var user = await db.Users.Where(u => u.Id == req.Id).FirstOrDefaultAsync(ct);

        if (user == null)
        {
            // Returns a more useful Problem Details complete with traceId etc., but we lose the
            // more expressive FastEndpoint function calls such as SendNotFoundAsync(), and are required
            // to declare an often lengthy Results<T> return value. We may also need to override
            // ExecuteAsync() instead of HandleAsync() depending on our implementation.
            //
            // This still sits on top of FastEndpoint's ProblemDetails which uses validation failures
            // under the hood, but this is far more explicit in setting exactly what we want to return.

            return new ProblemDetails { Status = 404, Detail = "User not found" };
        }

        var response = new Response
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };

        return TypedResults.Ok(response);
    }
}
