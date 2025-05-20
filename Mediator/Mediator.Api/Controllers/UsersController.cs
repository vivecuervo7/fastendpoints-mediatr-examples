using Mediator.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id, CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetUserQuery(id);
            var result = await sender.Send(query, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
