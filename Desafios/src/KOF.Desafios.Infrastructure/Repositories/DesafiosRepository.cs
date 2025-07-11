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

    public async Task<List<InformacionGeneral>> GetAllChallenges(int idDesafio, string idCliente, string idPais = "GT")
    {
        return await _context.InformacionGeneral
            .Where(x => x.IdDesafio == idDesafio && x.IdSegmentacion == 1)
            .ToListAsync();
    }
}
