using System.Reflection;
using Mediator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddMediatR(c =>
{
    var assembly = Assembly.Load("Mediator.Application");
    c.RegisterServicesFromAssembly(assembly);
});

var app = builder.Build();

await InitializeDatabase(app);

app.MapControllers();
app.UseHttpsRedirection();
app.Run();

static async Task InitializeDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}
