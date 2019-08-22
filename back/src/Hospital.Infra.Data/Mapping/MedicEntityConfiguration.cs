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

            builder.Property(m => m.UserId).HasColumnName("id_usuario");

            builder.HasDiscriminator<EMedicType>("tipo_medico")
                .HasValue<Medic>(EMedicType.General)
                .HasValue<Docent>(EMedicType.Docent)
                .HasValue<Resident>(EMedicType.Resident);

            
            builder.HasOne<User>(m => m.User)
                .WithOne(u => u.Medic)
                .HasForeignKey<Medic>(m => m.UserId);
            
        }
    }
}
