using System;
using KOF.Desafios.Domain.Entities.Desafios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOF.Desafios.Infrastructure.Persistence.Configurations;

public class InformacionGeneralConfiguration : IEntityTypeConfiguration<InformacionGeneral>
{
    public void Configure(EntityTypeBuilder<InformacionGeneral> builder)
    {
        builder.ToTable("InformacionGeneral", "desafio");

        builder.HasKey(e => e.IdDesafio);

        builder.Property(e => e.IdDesafio)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.IdSegmentacion).HasColumnType("int");

        builder.Property(e => e.TituloDesafio).HasColumnType("varchar(100)");

        builder.Property(e => e.DescripcionDesafio).HasColumnType("varchar(500)");

        builder.Property(e => e.LogotipoDesafio).HasColumnType("nvarchar(250)");

        builder.Property(e => e.Promocion).HasColumnType("varchar(50)");

        builder.Property(e => e.PuntosExtra).HasColumnType("int");

        builder.Property(e => e.Estatus).HasColumnType("varchar(15)");

        builder.Property(e => e.JsonMateriales).HasColumnType("varchar(max)");

        builder.Property(e => e.FechaInicio).HasColumnType("datetime");

        builder.Property(e => e.FechaFinalizacion).HasColumnType("datetime");

        builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

        builder.Property(e => e.UsuarioCreacion).HasColumnType("nvarchar(250)");

        builder.Property(e => e.FechaPublicacion).HasColumnType("datetime");

        builder.Property(e => e.UsuarioPublicacion).HasColumnType("nvarchar(250)");

        builder.Property(e => e.FechaCierre).HasColumnType("datetime");

        builder.Property(e => e.UsuarioCierre).HasColumnType("nvarchar(250)");

        builder.Property(e => e.FechaCancela).HasColumnType("datetime");

        builder.Property(e => e.UsuarioCancela).HasColumnType("nvarchar(250)");
    }
}