using Example_Mediator.Application.Exceptions;
using Example_Mediator.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example_Mediator.Api.Controllers;

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
        catch (NotFoundException ex)
        {
            return Problem(
                ex.Message,
                HttpContext.Request.Path,
                statusCode: StatusCodes.Status404NotFound
            );
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, HttpContext.Request.Path);
        }
    }
}
