using Microsoft.AspNetCore.Mvc;

namespace KOF.Desafios.PublicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InicioController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("🚀 Bienvenido a KOF.Desafios.API");
    }
}