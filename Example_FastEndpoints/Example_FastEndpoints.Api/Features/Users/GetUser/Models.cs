namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public class Request
{
    public int Id { get; set; }
}

public class Response
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
