using System;

namespace Hospital.Domain.Entities
{
    public class Patient
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public char Sex { get; set; }
        public string Color { get; set; }
        public DateTime Birthdate { get; set; }
    }
}