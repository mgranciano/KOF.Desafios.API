using System;
using KOF.Desafios.Domain.Entities.Desafios;
using Microsoft.EntityFrameworkCore;

namespace KOF.Desafios.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<InformacionGeneral> InformacionGeneral { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Configuración de la entidad InformacionGeneral
        // Configuración de la entidad InformacionGeneral
        modelBuilder.Entity<InformacionGeneral>(entity =>
        {
            //Nombre de la tabla y esquema
            entity.ToTable("InformacionGeneral", "desafio");

            //clave primaria con Identidad
            entity.HasKey(e => e.IdDesafio);
            entity.Property(e => e.IdDesafio)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();
            //Columnas
            entity.Property(e => e.IdSegmentacion)
                .HasColumnType("int");
            entity.Property(e => e.TituloDesafio)
                .HasColumnType("varchar(100)");
            entity.Property(e => e.TituloDesafio)
                .HasColumnType("varchar(100)");
            entity.Property(e => e.DescripcionDesafio)
                .HasColumnType("varchar(500)");
            entity.Property(e => e.LogotipoDesafio)
                .HasColumnType("nvarchar(250)");
            entity.Property(e => e.Promocion)
                .HasColumnType("varchar(50)");
            entity.Property(e => e.PuntosExtra)
                .HasColumnType("int");
            entity.Property(e => e.Estatus)
                .HasColumnType("varchar(15)");
            entity.Property(e => e.JsonMateriales)
                .HasColumnType("varchar(max)");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinalizacion)
                .HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasColumnType("nvarchar(250)");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioPublicacion)
                .HasColumnType("nvarchar(250)");
            entity.Property(e => e.FechaCierre)
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCierre)
                .HasColumnType("nvarchar(250)");
            entity.Property(e => e.FechaCancela)
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCancela)
                .HasColumnType("nvarchar(250)");

        });
        #endregion
    }
}
