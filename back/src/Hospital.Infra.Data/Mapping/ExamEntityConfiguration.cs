using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infra.Data.Mapping
{
    class ExamEntityConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("tb_exames");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Date)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(e => e.ExamPath)
                .HasColumnName("caminho_exame")
                .HasColumnType("varchar(300)");

            builder
                .HasOne(e => e.ExamRequest)
                .WithOne(er => er.Exam)
                .HasForeignKey<Exam>(e => e.Id);

            builder
                .HasOne(e => e.ExamReport)
                .WithOne(er => er.Exam)
                .HasForeignKey<ExamReport>(e => e.ExamId);

        }
    }
}
