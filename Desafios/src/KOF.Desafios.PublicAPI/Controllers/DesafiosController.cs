using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Services.Desafios;
using KOF.Desafios.Application.Validators;
using KOF.Desafios.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KOF.Desafios.PublicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesafiosController : ControllerBase
    {
        private readonly IDesafiosService _desafiosService;

        public DesafiosController(IDesafiosService desafiosService)
        {
            _desafiosService = desafiosService;
        }
        [HttpGet("GetAllChallenges")]
        public async Task<IActionResult> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
        {

            var result = await _desafiosService.GetAllChallenges(idDesafio, idCliente, idPais);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
