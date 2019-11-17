using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hospital.Domain.Mapping
{
    class DateConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime sourceMember, ResolutionContext context)
        {
            return sourceMember.ToShortDateString();
        }
    }
}
