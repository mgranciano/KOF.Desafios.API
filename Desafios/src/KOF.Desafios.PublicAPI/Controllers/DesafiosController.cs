using KOF.Desafios.Application.Common.Validators.Interfaces;
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
        private readonly IValidatorOrquestador _validatorOrquestador;

        public DesafiosController(IDesafiosService desafiosService, IValidatorOrquestador validatorOrquestador)
        {
            _desafiosService = desafiosService;
            _validatorOrquestador = validatorOrquestador;
        }

        [HttpGet("GetAllChallenges")]
        public async Task<IActionResult> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
        {
            // Validate the input parameters
            // await _validatorOrquestador.ValidateAsync(new { idDesafio, idCliente, idPais }, Operacion.Read);
            var result = await _desafiosService.GetAllChallenges(idDesafio, idCliente, idPais);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
