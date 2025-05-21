using Example_FastEndpoints.Infrastructure;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

await InitializeDatabase(app);

app.UseHttpsRedirection();

app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = e => e.AllowAnonymous();
});

app.Run();

static async Task InitializeDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}
