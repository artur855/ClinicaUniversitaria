using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.DTO
{
    public class ExamRequestDTO
    {
        public int Id { get; set; }
        public string Hypothesis { get; set; }
        public string ExpectedDate { get; set; }
        public string ExamName { get; set; }
        public string Recomendation { get; set; }
        public string MedicCrm { get; set; }
        public string MedicName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
