using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }

        public Medic Medic { get; set; }
        public Patient Patient { get; set; }
    }
}
