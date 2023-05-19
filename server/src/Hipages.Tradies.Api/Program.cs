
using Hipages.Tradies.Api;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("TradieApp Starting");

var builder = WebApplication.CreateBuilder(args);

Log.Information("TradieApp Starting - 1");

//builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
//    .WriteTo.Console()
//    .ReadFrom.Configuration(context.Configuration));

builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext(),
    true);

Log.Information("TradieApp Starting - 2 ");

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

Log.Information("TradieApp Starting - 3");

app.UseSerilogRequestLogging();

Log.Information("TradieApp Running");

app.Run();



public partial class Program { }
