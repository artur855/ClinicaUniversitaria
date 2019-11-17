using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infra.Data.Mapping
{
    public class ExamRequestConfiguration: IEntityTypeConfiguration<ExamRequest>
    {
        public void Configure(EntityTypeBuilder<ExamRequest> builder)
        {
            builder.ToTable("tb_pedidos_exames");
            builder.HasKey(er => er.Id);

            builder.Property(er => er.Id).HasColumnName("id");
            builder.Property(er => er.Recomendation).HasColumnName("recomendacao");
            builder.Property(er => er.Hypothesis).HasColumnName("hipotese_cid");
            builder.Property(er => er.ExamName).HasColumnName("exame");
            builder.Property(er => er.ExpectedDate).HasColumnName("data_prevista");
            builder.Property(er => er.MedicId).HasColumnName("id_medico");
            builder.Property(er => er.PatientId).HasColumnName("id_paciente");
            builder.Property(er => er.ExamReportId).HasColumnName("id_exam_report");

            builder
                .HasOne(er => er.Patient)
                .WithMany(p => p.ExamRequests)
                .HasForeignKey(er => er.PatientId);

            builder
                .HasOne(er => er.Medic)
                .WithMany(m => m.ExamRequests)
                .HasForeignKey(er => er.MedicId);

            builder
                .HasOne(e => e.ExamReport)
                .WithOne(er => er.ExamRequest)
                .HasForeignKey<ExamReport>(e => e.ExamRequestId);

            builder
                .HasOne(e => e.Exam)
                .WithOne(ex => ex.ExamRequest)
                .HasForeignKey<Exam>(ex => ex.Id);
            
            
        } 
    }
}