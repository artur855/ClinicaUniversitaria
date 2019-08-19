using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Entities
{
    public class Medic
    {
        public EMedicType MedicType { get; set; }
        public string CRM { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum EMedicType {
        General = 0,
        Docent = 1,
        Resident = 2,
    }
}
