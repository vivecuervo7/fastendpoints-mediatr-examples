using Example_FastEndpoints.Domain;
using Example_FastEndpoints.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Example_FastEndpoints.Api.Features.Users.GetUser;

public static class Data
{
    public static async Task<User?> GetUser(
        AppDbContext db,
        int id,
        CancellationToken cancellationToken
    )
    {
        return await db.Users.Where(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}
