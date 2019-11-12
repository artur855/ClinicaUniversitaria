namespace Hospital.Domain.Entities
{
    public class ExamReport : Entity
    {
        public ExamRequest ExamRequest;
        public  int ExamRequestId;

        public Resident Resident;
        public int ResidentId;

        public string Description;

        public int Cid;
    }
}