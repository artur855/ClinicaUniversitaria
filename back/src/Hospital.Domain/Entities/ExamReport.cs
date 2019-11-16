namespace Hospital.Domain.Entities
{
    public class ExamReport : Entity
    {
        public ExamRequest ExamRequest { get; set; }
        public int ExamRequestId { get; set; }

        public Resident Resident { get; set; }
        public int ResidentId { get; set; }

        public string Description { get; set; }

        public int Cid { get; set; }
    }
}