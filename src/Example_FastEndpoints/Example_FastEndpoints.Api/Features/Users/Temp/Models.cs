using FastEndpoints;
using FluentValidation;

namespace Example_FastEndpoints.Api.Features.Users.Temp;

public class Request
{
    public int Id { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).Must(x => x > 0).WithMessage("Id must be a positive integer");
    }
}

public class Response
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}