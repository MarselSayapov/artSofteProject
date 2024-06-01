using ExampleCore.TraceLogic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ExampleCore.TraceIdLogic;

public class ReadTraceIdMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ReadTraceIdMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context, IEnumerable<ITraceReader> traceReaderList)
    {
        foreach (var traceReader in traceReaderList)
        {
            traceReader.WriteValue(context.Request.Headers["TraceId"]!);
        }

        await _requestDelegate(context);
    }
}