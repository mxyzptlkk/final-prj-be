using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SK.FinalP.Application;
using SK.FinalP.Infrastructure;
using SK.FinalP.WebApi;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

LoggingConfiguration.AddConfigure();

builder.Host.UseSerilog();

builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!));
    
builder.Services.AddControllers();

builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

app.MapControllers();

app.UseSerilogRequestLogging();

Log.ForContext("SourceContext", "SK.FinalP.WebApi")
   .Information("Application starting...");

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.ForContext("SourceContext", "SK.FinalP.WebApi")
       .Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
