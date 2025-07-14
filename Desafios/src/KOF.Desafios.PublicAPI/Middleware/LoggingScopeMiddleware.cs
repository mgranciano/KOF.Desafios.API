using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KOF.Desafios.PublicAPI.Middleware;

public class LoggingScopeMiddleware
{
    private const string UID_HEADER = "X-Request-UID";

    public static string ContextKey => "RequestUID";

    private readonly RequestDelegate _next;

    public LoggingScopeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var uid = Guid.NewGuid().ToString();
        context.Items[ContextKey] = uid;
        context.Response.Headers[UID_HEADER] = uid;

        await _next(context);
    }
}