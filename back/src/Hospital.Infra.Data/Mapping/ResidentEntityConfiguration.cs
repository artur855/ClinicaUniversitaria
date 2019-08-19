using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infra.Data.Mapping
{
    public class ResidentEntityConfiguration : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder
                .ToTable("tb_medicos");

            builder
                .HasKey(r => r.CRM);

            builder.Property(r => r.InitialDate)
                .HasColumnName("ano_inicio")
                .HasColumnType("DATE");


            builder.Property(r => r.CRM)
                .HasColumnName("crm")
                .HasColumnType("VARCHAR(13)");

            builder.Property(r => r.MedicType)
                .HasColumnName("tipo_medico")
                .HasColumnType("CHAR(1)");
        }
    }
}
