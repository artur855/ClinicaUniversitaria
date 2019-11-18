using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Application.Command
{
    public class ExamRequestCommand
    {
        public int Id { get; set; }
        public string Hypothesis { get; set; }
        public string ExpectedDate { get; set; }
        public String ExamName { get; set; }
        public string Recomendation { get; set; }
        public string MedicCrm { get; set; }
        public int PatientId { get; set; }
    }
}
