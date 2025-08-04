using Example_FastEndpoints.Api.Extensions;
using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.ProblemDetailsExamples;

public class EndpointWithMvcProblemDetails : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/problem-details/mvc");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        // While this could be done here directly, using extension methods makes this more reusable. This
        // is probably the nicest balance between FastEndpoint's succinct syntax and providing useful and
        // expected problem details.

        await this.SendNotFoundProblemDetails("User not found", ct);
        return;
    }
}
