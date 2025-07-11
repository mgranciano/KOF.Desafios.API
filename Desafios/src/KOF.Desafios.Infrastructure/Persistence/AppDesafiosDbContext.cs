using System;
using KOF.Desafios.Domain.Entities.Desafios;
using Microsoft.EntityFrameworkCore;

namespace KOF.Desafios.Infrastructure.Repositories.Persistence;

public class AppDesafiosDbContext : DbContext
{
    public DbSet<InformacionGeneral> InformacionGeneral { get; set; }
    public DbSet<InformacionParticipante> InformacionParticipante { get; set; }
    
    public AppDesafiosDbContext(DbContextOptions<AppDesafiosDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDesafiosDbContext).Assembly);
    }
}
