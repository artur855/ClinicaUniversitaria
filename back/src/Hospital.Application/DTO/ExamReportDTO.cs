using Hospital.Domain.Entities;

namespace Hospital.Application.DTO
{
    public class ExamReportDTO
    {
        /*
         "examRequest": null,
        "examRequestId": 1,
        "medic": null,
        "residentId": 5,
        "description": "Ta feio",
        "cid": 1234,
        "id": 1
        */

        public string MedicName { get; set; }
        public int MedicId { get; set; }
        public int ExamRequestId { get; set; }
        public string Description { get; set; }
        public int Cid { get; set; }
        public ExamReportStatus Status { get; set; }
        public string ExamRequestName { get; set; }
    }
}