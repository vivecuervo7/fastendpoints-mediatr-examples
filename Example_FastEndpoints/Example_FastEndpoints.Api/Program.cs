using Example_FastEndpoints.Api.Features.CommandBusExample;
using Example_FastEndpoints.Api.Features.RemoteProcedureCallsExamples.RemoteEventQueue;
using Example_FastEndpoints.Api.JobStorage;
using Example_FastEndpoints.Api.Processors;
using Example_FastEndpoints.Infrastructure;
using Example_FastEndpoints_RpcServer.Contracts;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddJobQueues<JobRecord, JobStorageProvider>();
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

app.UseJobQueues(c =>
{
    c.MaxConcurrency = 2;
    c.ExecutionTimeLimit = TimeSpan.FromMinutes(10);
    // Set command-specific concurrency and time limits with c.LimitsFor<CommandName>();
});

app.MapRemote(
    "http://localhost:6000",
    c =>
    {
        // Namespace of command must match between this project and the RPC server. Using a project
        // reference makes sense here, but if the solutions live in different repositories it may be
        // necessary to use a non-standard (i.e. matching folder structure) namespace for the command
        c.Register<AddNumbersCommand, AddNumbersCommandResult>();

        c.RegisterEvent<UserCreatedEvent>();
        c.Subscribe<UserCreatedEvent, OnUserCreatedFirstEventHandler>();
        c.Subscribe<UserCreatedEvent, OnUserCreatedSecondEventHandler>();
    }
);

app.Run();

static async Task InitializeDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}
