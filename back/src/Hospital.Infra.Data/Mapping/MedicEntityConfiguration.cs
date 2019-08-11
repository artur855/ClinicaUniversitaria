using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infra.Data.Mapping
{
    public class MedicEntityConfiguration : IEntityTypeConfiguration<Medic>
    {
        public void Configure(EntityTypeBuilder<Medic> builder)
        {
            builder.ToTable("tb_medicos");

            builder.HasKey(m => m.CRM);

            builder.Property(m => m.CRM)
                .IsRequired()
                .HasColumnName("crm");

            builder.Property(m => m.Name)
                .IsRequired()
                .HasColumnName("nome");
        }
    }
}
