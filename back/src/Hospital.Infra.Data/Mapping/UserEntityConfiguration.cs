using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infra.Data.Mapping
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasColumnType("integer");

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(45)")
                .IsRequired();

            builder.Property(u => u.Name)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(150)");

            builder.Property(u => u.Password)
                .HasColumnName("senha")
                .HasColumnType("VARCHAR(45)")
                .IsRequired();

            builder.HasOne<Medic>(u => u.Medic)
                .WithOne(m => m.User)
                .HasForeignKey<Medic>(m => m.UserId);

            builder.HasOne<Patient>(u => u.Patient).
                WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId);
        }
    }
}
