using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoApi.Mapping
{
    public class ViagemMap : IEntityTypeConfiguration<Viagem>
    {
        public void Configure(EntityTypeBuilder<Viagem> entity)
        {
            entity.ToTable("viagem");

            entity.Property(e => e.ViagemId).HasColumnName("viagem_id");

            entity.Property(e => e.Destino)
                .HasColumnName("destino")
                .HasMaxLength(100);

            entity.Property(e => e.DtChegada)
                .HasColumnName("dt_chegada")
                .HasColumnType("date");

            entity.Property(e => e.DtPartida)
                .HasColumnName("dt_partida")
                .HasColumnType("date");

            entity.Property(e => e.DtPlanejado)
                .HasColumnName("dt_planejado")
                .HasColumnType("date");

            entity.Property(e => e.DtRecord).HasColumnName("dt_record");

            entity.Property(e => e.DtUpdate).HasColumnName("dt_update");

            entity.Property(e => e.NavioId).HasColumnName("navio_id");

            entity.Property(e => e.Origem)
                .HasColumnName("origem")
                .HasMaxLength(100);

            entity.HasOne(d => d.Navio)
                .WithMany(p => p.Viagem)
                .HasForeignKey(d => d.NavioId)
                .HasConstraintName("viagem_navio_id_fkey");
        }
    }
}
