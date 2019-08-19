using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Mapping
{
    public class PatientEntityConfiguration :IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("tb_pacientes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired().HasColumnName("id");
            builder.Property(p => p.Sex).IsRequired().HasColumnName("sexo");
            builder.Property(p => p.Birthdate).IsRequired().HasColumnName("dt_nasc");
            builder.Property(p => p.Color).IsRequired().HasColumnName("cor");

            builder.HasOne<User>(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId);
        }
    }
}