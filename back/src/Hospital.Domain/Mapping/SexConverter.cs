using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Mapping
{
    public class SexConverter : IValueConverter<char, string>
    {
        public string Convert(char sourceMember, ResolutionContext context)
        {
            if (sourceMember == 'M')
                return "Masculino";
            else if (sourceMember == 'F')
                return "Feminino";
            else
                return "Indeferido";

        }
    }
}
