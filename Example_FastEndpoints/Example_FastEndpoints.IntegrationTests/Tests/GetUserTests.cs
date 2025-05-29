using System.Net;
using Example_FastEndpoints.Api.Features.Users.GetUser;
using Example_FastEndpoints.Domain;
using Example_FastEndpoints.IntegrationTests.Infrastructure;
using FastEndpoints;
using FastEndpoints.Testing;
using Shouldly;

namespace Example_FastEndpoints.IntegrationTests.Tests;

public class GetUserTests(Fixture Fixture) : TestBase<Fixture>
{
    [Fact]
    public async Task GetUser_InValidInput_ReturnsFailure()
    {
        // Arrange
        var request = new Request { Id = 0 };

        // Act
        var (rsp, res) = await Fixture.Client.GETAsync<Endpoint, Request, ProblemDetails>(request);

        // Assert
        rsp.IsSuccessStatusCode.ShouldBeFalse();
        res.Errors.Count().ShouldBe(1);
        res.Errors.Select(e => e.Name).ShouldBe(["id"]);
    }

    [Fact]
    public async Task GetUser_ValidInput_UserNotExist_ReturnsNotFound()
    {
        // Arrange
        var request = new Request { Id = Fixture.DbContext.Users.Max(u => u.Id) + 1 };

        // Act
        var (rsp, res) = await Fixture.Client.GETAsync<Endpoint, Request, Response>(request);

        // Assert
        rsp.IsSuccessStatusCode.ShouldBeFalse();
        rsp.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetUser_ValidInput_ReturnsSuccess()
    {
        // Arrange
        var user = new User
        {
            Id = Fixture.DbContext.Users.Max(u => u.Id) + 1,
            Name = "Fred",
            Email = "fred@example.com",
        };

        Fixture.DbContext.Users.Add(user);
        await Fixture.DbContext.SaveChangesAsync(Fixture.Cancellation);

        var request = new Request { Id = user.Id };

        // Act
        var (rsp, res) = await Fixture.Client.GETAsync<Endpoint, Request, Response>(request);

        // Assert
        rsp.IsSuccessStatusCode.ShouldBeTrue();
        res.Name.ShouldBe("Fred");
    }
}
