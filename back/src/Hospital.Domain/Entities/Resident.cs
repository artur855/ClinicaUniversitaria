using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Entities
{
    public class Resident : Medic
    {
        public DateTime InitialDate { get; set; }
        
        public ICollection<ExamReport> ExamReports { get; set; }
        
    }
}
