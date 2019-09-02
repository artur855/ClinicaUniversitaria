using AutoMapper;
using Hospital.Domain.Command;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Mapping
{
    public class ModelToCommandProfile : Profile
    {
        public ModelToCommandProfile()
        {
            CreateMap<ExamRequest, ExamRequestCommand>()
                .ReverseMap();
        }
    }
}
