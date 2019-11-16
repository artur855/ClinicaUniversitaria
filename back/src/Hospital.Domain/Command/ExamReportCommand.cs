namespace Hospital.Domain.Command
{
    public class ExamReportCommand
    {
        public int ExamRequestId { get; set; }
        public string Description { get; set; }
        public int Cid { get; set; }
        
    }
}