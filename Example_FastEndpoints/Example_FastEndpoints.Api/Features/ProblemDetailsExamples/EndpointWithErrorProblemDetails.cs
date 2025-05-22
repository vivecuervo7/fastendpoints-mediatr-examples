using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.ProblemDetailsExamples;

public class EndpointWithErrorProblemDetails : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/problem-details/send-error");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        AddError("User not found");
        await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
        return;
    }
}
