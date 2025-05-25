using Example_FastEndpoints.Api.Features.CommandBusExample;
using Example_FastEndpoints.Api.Processors;
using Example_FastEndpoints.Infrastructure;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddCommandMiddleware(c => c.Register<DoubleValueCommand, int, CommandLogger>());
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

await InitializeDatabase(app);

app.UseHttpsRedirection();

app.UseFastEndpoints(c =>
{
    c.Errors.UseProblemDetails();

    c.Endpoints.Configurator = e =>
    {
        e.AllowAnonymous();
        e.PreProcessors(Order.Before, typeof(StartServerTiming<>));

        // A bug is preventing this from functioning correctly, so will need to be registered in
        // each endpoint that needs to log request duration
        // See: https://github.com/FastEndpoints/FastEndpoints/pull/950
        e.PostProcessors(Order.After, typeof(LogRequestDuration<,>));
    };

    c.Endpoints.GlobalResponseModifier = (ctx, content) =>
    {
        var serverTimingState = ctx.ProcessorState<ServerTimingState>();

        if (ctx.Response.SupportsTrailers())
        {
            ctx.Response.Headers.Trailer = "Server-Timing";
        }

        ctx.Response.Headers["Server-Timing"] = serverTimingState.ToServerTimingHeader();
    };
});

app.Run();

static async Task InitializeDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}
