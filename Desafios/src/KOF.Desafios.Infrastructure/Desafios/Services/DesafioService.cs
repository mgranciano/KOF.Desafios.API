using Microsoft.EntityFrameworkCore;
using KOF.Desafios.Application.Desafios.Dto;
using KOF.Desafios.Application.Desafios.Interfaces;
using KOF.Desafios.Domain.Entities;
using FluentValidation;
using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Infrastructure.Persistence;
using KOF.Desafios.Application.Common.Logging;

namespace KOF.Desafios.Infrastructure.Desafios.Services
{
    public class DesafioService : IDesafioService
    {
        private readonly DesafiosDbContext _context;
        private readonly IValidator<DesafioDto> _validator;
        private readonly IMapper<Desafio, DesafioDto> _mapper;
        private readonly ILogService _logService;

        public DesafioService(DesafiosDbContext context, IValidator<DesafioDto> validator, IMapper<Desafio, DesafioDto> mapper, ILogService logService)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<IEnumerable<DesafioDto>> GetAllAsync()
        {
            _logService.LogInfo("Obteniendo todos los desafíos");

            var entidades = await _context.Desafios.ToListAsync();
            return entidades.Select(_mapper.Map);
        }

        public async Task<DesafioDto?> GetByIdAsync(int id)
        {
            _logService.LogInfo($"Obteniendo desafío con ID {id}");
            var entidad = await _context.Desafios.FindAsync(id);
            return entidad == null ? null : _mapper.Map(entidad);
        }

        public async Task<DesafioDto> CreateAsync(DesafioDto dto)
        {
            _logService.LogInfo("Creando un nuevo desafío");
            await _validator.ValidateAndThrowAsync(dto);

            var entity = _mapper.MapBack(dto);
            _context.Desafios.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map(entity);
        }

        public async Task<DesafioDto> UpdateAsync(int id, DesafioDto dto)
        {
            _logService.LogInfo($"Actualizando desafío con ID {id}");
            await _validator.ValidateAndThrowAsync(dto);

            var entity = await _context.Desafios.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Desafío con ID {id} no encontrado.");

            entity.Titulo = dto.Titulo;
            entity.FechaInicio = dto.FechaInicio;

            await _context.SaveChangesAsync();
            return _mapper.Map(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logService.LogInfo($"Eliminando desafío con ID {id}");
            var entity = await _context.Desafios.FindAsync(id);
            if (entity == null)
                return false;

            _context.Desafios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}