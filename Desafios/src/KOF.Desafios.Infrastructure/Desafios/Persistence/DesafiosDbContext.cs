using Microsoft.EntityFrameworkCore;
using KOF.Desafios.Domain.Entities;

namespace KOF.Desafios.Infrastructure.Persistence
{
    public class DesafiosDbContext : DbContext
    {
        public DesafiosDbContext(DbContextOptions<DesafiosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Desafio> Desafios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Desafio>(entity =>
            {
                entity.ToTable("Desafios");

                entity.HasKey(d => d.Id);

                entity.Property(d => d.Titulo)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(d => d.FechaInicio)
                      .IsRequired();
            });
        }
    }
}