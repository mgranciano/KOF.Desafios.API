using KOF.Desafios.Application.Auth.Dto;
using KOF.Desafios.Application.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOF.Desafios.PublicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.AuthenticateAsync(request);
        if (response == null)
            return Unauthorized(new { message = "Credenciales inválidas." });

        return Ok(response);
    }
}