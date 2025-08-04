using Example_FastEndpoints.Domain;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class Mapper : Mapper<Request, Response, User>
{
    public override Task<Response> FromEntityAsync(User user, CancellationToken _)
    {
        return Task.FromResult(
            new Response
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            }
        );
    }
}
