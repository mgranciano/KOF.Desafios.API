using Microsoft.AspNetCore.Http;

namespace KOF.Desafios.Application.Common.Logging;

public interface ILogService
{
    void LogInfo(string message);
    void LogError(Exception ex);

    void LogInfo(HttpContext context, string message, string uid);
    void LogError(HttpContext context, Exception ex, string uid);
}