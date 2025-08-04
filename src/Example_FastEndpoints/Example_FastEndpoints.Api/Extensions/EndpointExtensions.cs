using FastEndpoints;

namespace Example_FastEndpoints.Api.Extensions;

public static class EndpointExtensions
{
    public static async Task SendNotFoundProblemDetails(
        this IEndpoint ep,
        string detail,
        CancellationToken cancellationToken = default
    )
    {
        ep.HttpContext.MarkResponseStart();
        ep.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        var problemDetails = TypedResults.Problem(
            detail,
            instance: ep.HttpContext.Request.Path,
            statusCode: ep.HttpContext.Response.StatusCode,
            title: "Not Found",
            extensions: new Dictionary<string, object?>
            {
                ["traceId"] = ep.HttpContext.TraceIdentifier
            }
        );

        await ep.HttpContext.Response.WriteAsJsonAsync(
            problemDetails.ProblemDetails,
            cancellationToken: cancellationToken
        );

        await ep.HttpContext.Response.StartAsync(cancellationToken);
    }
}
