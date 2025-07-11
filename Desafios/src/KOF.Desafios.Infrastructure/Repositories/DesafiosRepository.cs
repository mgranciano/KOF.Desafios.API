using System;
using KOF.Desafios.Application.Interfaces.Desafios;
using KOF.Desafios.Domain.Entities.Desafios;
using KOF.Desafios.Infrastructure.Repositories.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KOF.Desafios.Infrastructure.Repositories;

public class DesafiosRepository : IDesafiosRepository
{
    private readonly AppDesafiosDbContext _context;

    public DesafiosRepository(AppDesafiosDbContext context)
    {
        _context = context;
    }

    public async Task<InformacionGeneral> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
    {
        return await _context.InformacionGeneral
            .FirstOrDefaultAsync(x => x.IdDesafio == idDesafio && x.IdSegmentacion == 1) ?? new InformacionGeneral();
    }
}
