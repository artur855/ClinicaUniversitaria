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
            
            builder.HasKey(er => er.ExamRequestId);

            builder.Property(er => er.Cid).HasColumnName("cid").IsRequired();
            
            builder.HasOne(er => er.Resident).WithMany(r => r.ExamReports)
                .HasForeignKey(er => er.ResidentId);

            builder.HasOne(er => er.ExamRequest).WithOne(er => er.ExamReport);
        }
    }
}