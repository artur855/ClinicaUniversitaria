using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Application.DTO
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public int ExamRequestId { get; set; }
        public string Date { get; set; }
        public string MedicName { get; set; }
        public string MedicCRM { get; set; }
        public string PatientName { get; set; }
    }
}
