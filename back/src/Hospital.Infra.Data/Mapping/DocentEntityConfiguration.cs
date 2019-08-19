using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infra.Data.Mapping
{
    public class DocentEntityConfiguration : IEntityTypeConfiguration<Docent>
    {
        public void Configure(EntityTypeBuilder<Docent> builder)
        {
            builder.ToTable("tb_medicos");

            builder
                .HasKey(d => d.CRM);

            builder.Property(d => d.CRM)
                .HasColumnName("crm")
                .HasColumnType("VARCHAR(13)");

            builder.Property(d => d.Titulation)
                .HasColumnName("titulacao")
                .HasColumnType("VARCHAR(45)");

            builder.Property(d => d.MedicType)
                .HasColumnName("tipo_medico")
                .HasColumnType("CHAR(1)");
        }
    }
}
