using System;
using System.Linq;
using Hospital.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace Hospital.Domain.Converters
{
    public class PersonJsonConverter : BaseConverter<Medic>
    {
        protected override Medic Create(Type objectType, JObject jObject)
        {
            var properties = jObject.Properties();
            var lowerProperties = properties.Select(x => x.Name.ToLower()).ToList();
            if (lowerProperties.Contains("titulation"))
                return new Docent();
            if (lowerProperties.Contains("initialdate"))
                return new Resident();
            
            return new Medic();
        }
    }
}