using System;
using KOF.Desafios.Application.Entities.Desafios.Request;
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

    public async Task<List<InformacionGeneral>> GetAllChallenges(DesafioRequest request)
    {
        return await _context.InformacionGeneral
            .ToListAsync();
    }
}
