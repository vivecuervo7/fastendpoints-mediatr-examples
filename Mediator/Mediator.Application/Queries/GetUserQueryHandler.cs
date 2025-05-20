using Mediator.Domain;
using Mediator.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Application.Queries;

public class GetUserQueryHandler(AppDbContext db) : IRequestHandler<GetUserQuery, User>
{
    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await db
            .Users.Where(u => u.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }
}
