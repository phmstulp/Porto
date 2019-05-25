using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoApi.Mapping
{
    public class NavioMap : IEntityTypeConfiguration<Navio>
    {
        public void Configure(EntityTypeBuilder<Navio> entity)
        {
            entity.ToTable("navio");

            entity.Property(e => e.NavioId).HasColumnName("navio_id");

            entity.Property(e => e.Capacidade).HasColumnName("capacidade");

            entity.Property(e => e.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(100);

            entity.Property(e => e.DtRecord).HasColumnName("dt_record");

            entity.Property(e => e.DtUpdate).HasColumnName("dt_update");
        }
    }
}
