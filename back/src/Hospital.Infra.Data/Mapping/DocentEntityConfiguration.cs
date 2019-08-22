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

            builder.Property(d => d.Titulation)
                .HasColumnName("titulacao")
                .HasColumnType("VARCHAR(45)");


        }
    }
}
