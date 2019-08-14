using System;
using System.Data;

namespace Hospital.Domain.Entities
{
    public class Patient
    {
        public void Update(Patient newPatient)
        {
            this.Id = newPatient.Id;
            this.Name = newPatient.Name;
            this.Sex = newPatient.Sex;
            this.Color = newPatient.Color;
            this.Birthdate = newPatient.Birthdate;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public char Sex { get; set; }
        public PatientColors Color { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public enum PatientColors
    {
        Branco = 0,
        Negro = 1,
        Pardo = 2,
        Indigena = 3,
        Naoespecificado = 4
    }
}