using Example_FastEndpoints.Infrastructure;
using FastEndpoints.Testing;

namespace Example_FastEndpoints.IntegrationTests.Infrastructure;

public class Fixture : AppFixture<Program>
{
    public AppDbContext DbContext { get; set; } = default!;

    protected override ValueTask SetupAsync()
    {
        DbContext = new AppDbContext();
        return ValueTask.CompletedTask;
    }
}
