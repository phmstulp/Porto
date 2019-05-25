﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortoApi.Mapping
{
    public class ContainerMap : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> entity)
        {
            entity.ToTable("container");

            entity.Property(e => e.ContainerId).HasColumnName("container_id");

            entity.Property(e => e.Altura)
                .HasColumnName("altura")
                .HasColumnType("numeric(10,2)");

            entity.Property(e => e.Capacidade)
                .HasColumnName("capacidade")
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.Comprimento)
                .HasColumnName("comprimento")
                .HasColumnType("numeric(10,2)");

            entity.Property(e => e.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(100);

            entity.Property(e => e.DtRecord).HasColumnName("dt_record");

            entity.Property(e => e.DtUpdate).HasColumnName("dt_update");

            entity.Property(e => e.DtVencimento)
                .HasColumnName("dt_vencimento")
                .HasColumnType("date");

            entity.Property(e => e.Largura)
                .HasColumnName("largura")
                .HasColumnType("numeric(10,2)");

            entity.Property(e => e.Tipo).HasColumnName("tipo");
        }
    }
}
