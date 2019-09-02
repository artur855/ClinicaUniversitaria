using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.DTO
{
    public class MedicDTO
    {
        public string CRM { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
