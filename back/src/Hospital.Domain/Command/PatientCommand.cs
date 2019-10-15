using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Command
{
    public class PatientCommand
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public PatientColors Color { get; set; }
        public string Birthdate { get; set; }
        public User User { get; set; }
    }
}
