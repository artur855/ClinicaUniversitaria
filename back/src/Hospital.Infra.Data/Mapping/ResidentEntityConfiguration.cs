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

            builder.Property(r => r.InitialDate)
                .HasColumnName("ano_inicio")
                .HasColumnType("DATE");

            builder
                .HasMany(r => r.ExamReports)
                .WithOne(er => er.Resident)
                .HasForeignKey(er => er.ResidentId);

        }
    }
}
