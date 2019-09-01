using System.Collections.Generic;
using Hospital.Domain.Converters;
using Newtonsoft.Json;

namespace Hospital.Domain.Entities
{
    [JsonConverter(typeof(PersonJsonConverter))]
    public class Medic
    {
        public string CRM { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ExamRequest> ExamRequests { get; set; }
    }

    public enum EMedicType {
        General = 0, 
        Docent = 1,
        Resident = 2,
    }
}
