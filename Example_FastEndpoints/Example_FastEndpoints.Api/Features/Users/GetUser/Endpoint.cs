using Example_FastEndpoints.Infrastructure;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class Endpoint(AppDbContext db, ILogger<Request> logger)
    : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/users/{Id}");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await Data.GetUser(db, req.Id, ct);

        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendMappedAsync(user, ct: ct);

        logger.LogInformation("Successfully sent user response");
    }
}
