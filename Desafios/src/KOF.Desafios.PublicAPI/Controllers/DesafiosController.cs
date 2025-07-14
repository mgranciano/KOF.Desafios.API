using Microsoft.AspNetCore.Mvc;
using KOF.Desafios.Application.Desafios.Dto;
using KOF.Desafios.Application.Desafios.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using KOF.Desafios.Application.Common.Logging;
using KOF.Desafios.Domain.Entities;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Application.Common.Validators.Interfaces;
using KOF.Desafios.Domain.Common.Enums;
using KOF.Desafios.Application.Dtos.Desafios;

namespace KOF.Desafios.PublicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class DesafiosController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDesafioService _desafioService;
        private readonly IValidatorOrquestador _validatorOrquestador;

        public DesafiosController(ILogService logService, IDesafioService desafioService, IValidatorOrquestador validatorOrquestador)
        {
            _logService = logService;
            _desafioService = desafioService;
            _validatorOrquestador = validatorOrquestador;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] DesafioRequestDto requestDto)
        {
            {
                _logService.LogInfo("Inicio de consulta de desafío");
                await _validatorOrquestador.ValidateAsync(requestDto, Operacion.Read);
                var desafios = await _desafioService.GetAllAsync(requestDto);
                return Ok(desafios);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logService.LogInfo($"Inicio de consulta de desafío por ID: {id}");
            if (id <= 0)
                return BadRequest("ID must be greater than zero");

            var desafio = await _desafioService.GetByIdAsync(id);
            if (desafio == null)
                return NotFound("Registro no encontrado");
            return Ok(desafio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InformacionGeneralDto dto)
        {
            _logService.LogInfo("Inicio de creación de nuevo desafío");

            await _validatorOrquestador.ValidateAsync(dto, Operacion.Create);

            var created = await _desafioService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdDesafio }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InformacionGeneralDto dto)
        {
            _logService.LogInfo($"Inicio de actualización de desafío con ID: {id}");

            if (id != dto.IdDesafio)
                return BadRequest("ID mismatch");

            await _validatorOrquestador.ValidateAsync(dto, Operacion.Update);


            var updated = await _desafioService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logService.LogInfo($"Inicio de eliminación de desafío con ID: {id}");

            await _desafioService.DeleteAsync(id);
            return NoContent();
        }
    }
}