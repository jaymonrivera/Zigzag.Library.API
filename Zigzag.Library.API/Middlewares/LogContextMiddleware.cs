using Serilog.Context;

namespace Zigzag.Library.API.Middlewares;

public class LogContextMiddleware
{
    private readonly RequestDelegate _next;

    public LogContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    { 
        var correlationId = Guid.NewGuid().ToString();

        LogContext.PushProperty("ServiceName", "Zigzag.Library.Api");
        LogContext.PushProperty("CorrelationId", correlationId);
        LogContext.PushProperty("MachineName", Environment.MachineName);

        await _next(context);
    }
}
