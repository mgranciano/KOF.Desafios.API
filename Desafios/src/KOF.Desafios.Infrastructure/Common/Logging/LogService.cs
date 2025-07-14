using KOF.Desafios.Application.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace KOF.Desafios.Infrastructure.Common.Logging;

public class LogService : ILogService
{
    private readonly ILogger<LogService> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogService(ILogger<LogService> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public void LogInfo(string message)
    {
        var context = _httpContextAccessor.HttpContext;

        if (context is null)
        {
            _logger.LogInformation("[NoHttpContext] - {Message}", message);
            return;
        }

        var routeData = context.GetRouteData();
        var controller = routeData.Values["controller"]?.ToString() ?? "UnknownController";
        var method = routeData.Values["action"]?.ToString() ?? "UnknownAction";
        var uid = context.Items["UID"]?.ToString() ?? Guid.NewGuid().ToString();

        _logger.LogInformation("[{Uid}] {Controller}.{Method} - {Message}", uid, controller, method, message);
    }

    public void LogError(Exception ex)
    {
        var context = _httpContextAccessor.HttpContext;

        var routeData = context?.GetRouteData();
        var controller = routeData?.Values["controller"]?.ToString() ?? "UnknownController";
        var method = routeData?.Values["action"]?.ToString() ?? "UnknownAction";
        var uid = context?.Items["UID"]?.ToString() ?? Guid.NewGuid().ToString();

        _logger.LogError(ex, "[{Uid}] {Controller}.{Method} - Exception occurred", uid, controller, method);
    }

    // Métodos actuales aún disponibles si los necesitas
    public void LogInfo(HttpContext context, string message, string uid)
    {
        var routeData = context.GetRouteData();
        var controller = routeData.Values["controller"]?.ToString() ?? "UnknownController";
        var method = routeData.Values["action"]?.ToString() ?? "UnknownAction";

        _logger.LogInformation("[{Uid}] {Controller}.{Method} - {Message}", uid, controller, method, message);
    }

    public void LogError(HttpContext context, Exception ex, string uid)
    {
        var routeData = context.GetRouteData();
        var controller = routeData.Values["controller"]?.ToString() ?? "UnknownController";
        var method = routeData.Values["action"]?.ToString() ?? "UnknownAction";

        _logger.LogError(ex, "[{Uid}] {Controller}.{Method} - Exception occurred", uid, controller, method);
    }
}