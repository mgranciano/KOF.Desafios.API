using Microsoft.EntityFrameworkCore;
using KOF.Desafios.Application.Desafios.Dto;
using KOF.Desafios.Application.Desafios.Interfaces;
using KOF.Desafios.Domain.Entities;
using FluentValidation;
using KOF.Desafios.Application.Common.Mappings;
using KOF.Desafios.Application.Common.Mappings.Interfaces;
using KOF.Desafios.Infrastructure.Persistence;
using KOF.Desafios.Application.Common.Logging;
using KOF.Desafios.Application.Dtos.Desafios;
using KOF.Desafios.Application.Dtos.Desafios.Request;
using KOF.Desafios.Domain.Entities.Desafios;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Application.Entities.Desafios.Request;
using KOF.Desafios.Application.Desafios.Entities.Request;

namespace KOF.Desafios.Infrastructure.Desafios.Services
{
    public class DesafiosRepository : IDesafiosRepository
    {
        private readonly DesafiosDbContext _context;
        private readonly IMapper<InformacionGeneral, InformacionGeneralDto> _mapper;
        private readonly ILogService _logService;

        public DesafiosRepository(DesafiosDbContext context, IMapper<InformacionGeneral, InformacionGeneralDto> mapper, ILogService logService)
        {
            _context = context;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<InformacionGeneral> CreateAsync(InformacionGeneral desafio)
        {
            _logService.LogInfo("Creating new desafio");
            _context.InformacionGeneral.Add(desafio);
            await _context.SaveChangesAsync();
            _logService.LogInfo($"Desafio created with ID: {desafio.IdDesafio}");

            return desafio;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logService.LogInfo($"Deleting desafio with ID: {id}");
            var desafio = await _context.InformacionGeneral.FindAsync(id);
            if (desafio == null)
            {
                return false;
            }

            desafio.Estatus = "Eliminado";
            _context.InformacionGeneral.Update(desafio);
            await _context.SaveChangesAsync();
            _logService.LogInfo($"Desafio with ID: {id} deleted successfully");
            return true;
        }

        public async Task<List<InformacionGeneral>> GetAllAsync(DesafioRequest request)
        {
            return await _context.InformacionGeneral
            .Where(x => x.IdSegmentacion != 0)
            .ToListAsync();
        }

        public async Task<InformacionGeneral?> GetByIdAsync(int id)
        {
            return await _context.InformacionGeneral.FindAsync(id);
        }

        public async Task<InformacionGeneral> UpdateAsync(InformacionGeneralUpdate desafio)
        {
            var entity = await _context.InformacionGeneral.FindAsync(desafio.IdDesafio);
            if (entity == null)
            {
                throw new Exception("Desafio not found");
            }

            entity.TituloDesafio = desafio.TituloDesafio;
            entity.DescripcionDesafio = desafio.DescripcionDesafio;
            entity.LogotipoDesafio = desafio.LogotipoDesafio;
            entity.Promocion = desafio.Promocion;
            entity.PuntosExtra = desafio.PuntosExtra;

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}