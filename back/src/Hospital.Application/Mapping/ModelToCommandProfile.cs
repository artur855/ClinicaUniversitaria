using AutoMapper;
using Hospital.Application.Command;
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
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Patient.Id))
                .ReverseMap();

            CreateMap<User, UserCommand>()
                .ReverseMap();

            CreateMap<Patient, PatientCommand>()
                .ForMember(dest => dest.Birthdate, opt => opt.ConvertUsing(new DateConverter(), src => src.Birthdate))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<Exam, PerformExamCommand>()
                .ForMember(dest => dest.Date, opt => opt.ConvertUsing(new DateConverter(), src => src.Date))
                .ReverseMap();

            CreateMap<LoginCommand, User>();

        }
    }
}
