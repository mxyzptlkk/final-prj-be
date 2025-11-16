namespace SK.FinalP.WebApi;

using Serilog;
using Serilog.Filters;

public static class LoggingConfiguration
{
    public static void AddConfigure()
    {
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .WriteTo.Logger(x => x
            .Filter.ByIncludingOnly(Matching.FromSource("SK.FinalP.Application"))
            .WriteTo.Console()
            .WriteTo.File(
                "Logs/Application/.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {SourceContext}: {Message}{NewLine}{Exception}"
        ))
        .WriteTo.Logger(x => x
            .Filter.ByIncludingOnly(Matching.FromSource("SK.FinalP.Infrastructure"))
            .WriteTo.Console()
            .WriteTo.File(
                "Logs/Infrastructure/.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {SourceContext}: {Message}{NewLine}{Exception}"
        ))
        .WriteTo.Logger(x => x
            .Filter.ByIncludingOnly(Matching.FromSource("SK.FinalP.WebApi"))
            .WriteTo.Console()
            .WriteTo.File(
                "Logs/WebApi/.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {SourceContext}: {Message}{NewLine}{Exception}"
        ))
        .WriteTo.Logger(x => x
            .Filter.ByIncludingOnly(Matching.FromSource("Microsoft"))
            .WriteTo.Console()
            .WriteTo.File(
                "Logs/System/.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {SourceContext}: {Message}{NewLine}{Exception}"
        ))
        .CreateLogger();
    }
}
