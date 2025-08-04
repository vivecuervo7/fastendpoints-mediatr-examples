using Example_FastEndpoints.Api.Features.Users.GetUser;
using Example_FastEndpoints.Domain;
using Example_FastEndpoints.Infrastructure;
using FastEndpoints;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Shouldly;

namespace Example_FastEndpoints.UnitTests.Tests;

public class GetUserTests
{
    [Fact]
    public async Task GetUser_Success()
    {
        // Arrange
        var logger = Substitute.For<ILogger<Request>>();

        // Since we're running this with in-memory SQLite anyway, just use the existing implementation
        var dbContext = new AppDbContext();
        await dbContext.Database.EnsureCreatedAsync(CancellationToken.None);

        var user = new User
        {
            Id = dbContext.Users.Max(u => u.Id) + 1,
            Name = "Fred",
            Email = "fred@example.com",
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(CancellationToken.None);

        var ep = Factory.Create<Endpoint>(dbContext, logger);
        var req = new Request { Id = user.Id };

        // Act
        await ep.HandleAsync(req, CancellationToken.None);
        var rsp = ep.Response;

        // Assert
        rsp.ShouldNotBeNull();
        rsp.Name.ShouldBe("Fred");
    }
}
