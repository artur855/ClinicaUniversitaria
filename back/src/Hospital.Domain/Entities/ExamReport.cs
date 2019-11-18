namespace Hospital.Domain.Entities
{
    public class ExamReport : Entity
    {
        public ExamRequest ExamRequest { get; set; }
        public int ExamRequestId { get; set; }

        public Medic Medic { get; set; }
        public int MedicId { get; set; }

        public string Description { get; set; }
        public ExamReportStatus Status { get; set; }
        public int Cid { get; set; }
    }

    public enum ExamReportStatus
    {
        ANDAMENTO = 0,
        APROVADO = 1,
        NEGADO = 2
    }
}