using System;

namespace Hospital.Domain.Entities
{
    public class ExamRequest
    {
        public int Id { get; set; }
        public string Hypothesis { get; set; }
        public string Recomendation { get; set; }
        public DateTime ExpectedDate { get; set; }
        public ExamType ExamName { get; set; }
        
        public string MedicCrm { get; set; }
        public Medic Medic { get; set; }
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }

    public enum ExamType
    {
        Ecocardiograma = 0,
        Eletrocardiograma = 1,
        Mapa = 2,
        Holter = 3
    }
}