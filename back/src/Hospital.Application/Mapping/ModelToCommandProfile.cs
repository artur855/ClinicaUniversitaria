using AutoMapper;
using Hospital.Application.Command;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Domain.Mapping;

namespace Hospital.Application.Mapping
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

            CreateMap<ExamRequest, ExamRequestCommand>()
                .ForMember(dest => dest.ExpectedDate, opt => opt.ConvertUsing(new DateConverter(), src => src.ExpectedDate))
                .ReverseMap();

            CreateMap<LoginCommand, User>();

            CreateMap<ExamReportCommand, ExamReport>()
                .ForMember(dest => dest.ExamRequestId, opt => opt.MapFrom(src => src.ExamRequestId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Cid, opt => opt.MapFrom(src => src.Cid))
                .ReverseMap();

            CreateMap<UpdateExamReportCommand, ExamReport>()
                .ForMember(dest => dest.ExamRequestId, opt => opt.MapFrom(src => src.ExamRequestId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.MedicId, opt => opt.MapFrom(src => src.MedicId))
                .ReverseMap();
        }
    }
}
