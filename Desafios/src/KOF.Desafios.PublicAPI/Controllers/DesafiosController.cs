using Microsoft.AspNetCore.Mvc;
using KOF.Desafios.Application.Desafios.Dto;
using KOF.Desafios.Application.Desafios.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using KOF.Desafios.Application.Common.Logging;

namespace KOF.Desafios.PublicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DesafiosController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDesafioService _desafioService;
        private readonly IValidator<DesafioDto> _validator;

        public DesafiosController(ILogService logService, IDesafioService desafioService, IValidator<DesafioDto> validator)
        {
            _logService = logService;
            _desafioService = desafioService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logService.LogInfo("Inicio de consulta de desafío");

            var desafios = await _desafioService.GetAllAsync();
            return Ok(desafios);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logService.LogInfo($"Inicio de consulta de desafío por ID: {id}");

            var desafio = await _desafioService.GetByIdAsync(id);
            if (desafio == null)
                return NotFound();
            return Ok(desafio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DesafioDto dto)
        {
            _logService.LogInfo("Inicio de creación de nuevo desafío");

            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var created = await _desafioService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DesafioDto dto)
        {
            _logService.LogInfo($"Inicio de actualización de desafío con ID: {id}");

            if (id != dto.Id)
                return BadRequest("ID mismatch");

            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

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