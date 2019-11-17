using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Entities
{
    public class Exam : Entity
    {
        public string ExamPath { get; set; }
        public DateTime Date { get; set; }

        public ExamRequest ExamRequest { get; set; }
        public int ExamRequestId { get; set; }

        public ExamReport ExamReport { get; set; }

    }
}
