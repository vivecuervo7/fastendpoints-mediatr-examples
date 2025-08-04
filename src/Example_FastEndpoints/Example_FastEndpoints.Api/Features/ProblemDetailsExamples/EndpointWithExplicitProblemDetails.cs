using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.ProblemDetailsExamples;

public class EndpointWithExplicitProblemDetails : EndpointWithoutRequest<ProblemDetails>
{
    public override void Configure()
    {
        Get("/problem-details/explicit");
    }

    public override Task<ProblemDetails> ExecuteAsync(CancellationToken ct)
    {
        // Returns a Problem Details complete with traceId etc., but we lose the more expressive
        // FastEndpoint function calls such as SendNotFoundAsync(), and are required to declare
        // an often lengthy Results<T> return value. We may also need to override ExecuteAsync()
        // instead of HandleAsync(), depending on our implementation.
        //
        // This still sits on top of FastEndpoint's ProblemDetails which uses validation failures
        // under the hood, but this is far more explicit in setting exactly what we want to return.

        var problem = new ProblemDetails { Status = 404, Detail = "User not found" };
        return Task.FromResult(problem);
    }
}
