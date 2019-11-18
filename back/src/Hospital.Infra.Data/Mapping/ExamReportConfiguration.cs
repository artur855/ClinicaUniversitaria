using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Mapping
{
    public class ExamReportConfiguration : IEntityTypeConfiguration<ExamReport>
    {
        public void Configure(EntityTypeBuilder<ExamReport> builder)
        {
            builder.ToTable("tb_pedidos_laudos");
            
            builder.HasKey(er => er.Id);

            builder.Property(er => er.Cid)
                .HasColumnName("cid")
                .IsRequired();
            
            builder
                .HasOne(er => er.Medic)
                .WithMany(r => r.ExamReports)
                .HasForeignKey(er => er.MedicId);

            builder
                .HasOne(er => er.ExamRequest)
                .WithOne(er => er.ExamReport)
                .HasForeignKey<ExamReport>(e => e.ExamRequestId);

            builder.Property(er => er.Status).HasColumnName("status").IsRequired();

            builder
                .HasOne(e => e.Exam)
                .WithOne(ex => ex.ExamReport)
                .HasForeignKey<ExamReport>(e => e.ExamId);
        }
    }
}