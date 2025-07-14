using System;
using KOF.Desafios.Domain.Entities.Desafios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOF.Desafios.Infrastructure.Persistence.Configurations;

public class InformacionParticipanteConfiguration : IEntityTypeConfiguration<InformacionParticipante>
{
    public void Configure(EntityTypeBuilder<InformacionParticipante> builder)
    {
        builder.ToTable("InformacionParticipante", "desafio");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.IdDesafio).HasColumnType("int");

        builder.Property(e => e.IdCliente)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(e => e.IdEstatusDesafio).HasColumnType("int");

        builder.Property(e => e.FechaInicio).HasColumnType("datetime");

        builder.Property(e => e.FechaFinalizacion).HasColumnType("datetime");

        builder.Property(e => e.FechaUltimaActualizacion).HasColumnType("datetime");
    }
}
