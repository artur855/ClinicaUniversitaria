using Hospital.Domain.Entities;

namespace Hospital.Application.Command
{
    public class UpdateExamReportCommand
    {
        public int ExamRequestId;
        public ExamReportStatus Status;
        public int MedicId;
    }
}