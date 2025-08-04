using Example_FastEndpoints_RpcServer.Api;
using Example_FastEndpoints_RpcServer.Contracts;
using FastEndpoints;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(o =>
{
    // Accept only HTTP/2 to allow insecure connections for development
    o.ListenLocalhost(6000, o => o.Protocols = HttpProtocols.Http2);
});

builder.AddHandlerServer();

var app = builder.Build();

app.MapHandlers(h =>
{
    h.Register<AddNumbersCommand, AddNumbersCommandHandler, AddNumbersCommandResult>();
    h.RegisterEventHub<UserCreatedEvent>(HubMode.EventBroker);
});

app.Run();
