using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Hospital.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public Medic Medic { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
