using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;
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

        [HttpPost("GetAllChallenges")]
        public async Task<IActionResult> GetAllChallenges([FromBody] DesafioRequestDto request)
        {
            // Validate the input parameters
            await _validatorOrquestador.ValidateAsync(request, Operacion.Read);
            var result = await _desafiosService.GetAllChallenges(request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
