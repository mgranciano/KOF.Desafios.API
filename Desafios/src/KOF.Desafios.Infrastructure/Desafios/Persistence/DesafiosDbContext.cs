using Microsoft.EntityFrameworkCore;
using KOF.Desafios.Domain.Entities;
using KOF.Desafios.Domain.Entities.Desafios;

namespace KOF.Desafios.Infrastructure.Persistence
{
    public class DesafiosDbContext : DbContext
    {
        public DbSet<InformacionGeneral> InformacionGeneral { get; set; }
        public DbSet<InformacionParticipante> InformacionParticipante { get; set; }

        public DesafiosDbContext(DbContextOptions<DesafiosDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafiosDbContext).Assembly);
        }
    }
}
