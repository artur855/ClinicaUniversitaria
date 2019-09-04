using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public string Color { get; set; }
        public string Birthdate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
