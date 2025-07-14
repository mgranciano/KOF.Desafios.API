using KOF.Desafios.Application.Common.Context;

namespace KOF.Desafios.PublicAPI.Middleware;

public class RequestContextMiddleware
{
    private readonly RequestDelegate _next;

    public RequestContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, RequestContext requestContext)
    {
        requestContext.Uid = Guid.NewGuid().ToString();
        context.Items["UID"] = requestContext.Uid;

        await _next(context);
    }
}