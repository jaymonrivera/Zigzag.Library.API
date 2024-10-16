using ILogger = Microsoft.Extensions.Logging.ILogger;
using Serilog;

namespace Zigzag.Library.API.Infra.Logging;

public static class ZigzagApiLog
{
    private static ILoggerFactory _loggerFactory = null!;

    public static void Initialize()
    {
        var loggerConfig = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}");

        Log.Logger = loggerConfig
            .CreateBootstrapLogger();

        _loggerFactory = LoggerFactory.Create(builder => builder
            .AddSerilog(Log.Logger, dispose: true));
    }

    public static ILoggerFactory GetFactoryInstance() => _loggerFactory;

    public static ILogger CreateLogger<T>()
    {
        return _loggerFactory.CreateLogger<T>();
    }

}
