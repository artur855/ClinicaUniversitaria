using System;
using System.Collections.Generic;
using System.Data;

namespace Hospital.Domain.Entities
{
    public class Patient : Entity
    {
        public void Update(Patient newPatient)
        {
            this.Id = newPatient.Id;
            this.Sex = newPatient.Sex;
            this.Color = newPatient.Color;
            this.Birthdate = newPatient.Birthdate;
        }

        public char Sex { get; set; }
        public PatientColors? Color { get; set; }
        public DateTime Birthdate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ExamRequest> ExamRequests { get; set; }



        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int years = now.Year - Birthdate.Year;
                if (now.Month < Birthdate.Month ||  (now.Month == Birthdate.Month && now.Day < Birthdate.Day))
                {
                    years--;
                }
                if (years < 0)
                    throw new ArithmeticException($"Idade do paciente {Id} é negativa");
                return years;
            }
        }
        
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