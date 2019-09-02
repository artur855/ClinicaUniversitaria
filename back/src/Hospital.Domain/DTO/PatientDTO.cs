using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public char Sex { get; set; }
        public PatientColors Color { get; set; }
        public DateTime Birthdate { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
