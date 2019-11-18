using AutoMapper;
using Hospital.Application.DTO;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<ExamRequest, ExamRequestDTO>()
                .ForMember(dest => dest.MedicName, opt => opt.MapFrom(src => src.Medic.User.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.User.Name))
                .ForMember(dest => dest.ExpectedDate, opt => opt.ConvertUsing(new DateConverter(), src => src.ExpectedDate))
                .ReverseMap();

            CreateMap<Medic, MedicDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Resident, ResidentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.InitialDate, opt => opt.ConvertUsing(new DateConverter(), src => src.InitialDate))
                .ReverseMap();

            CreateMap<Docent, DocentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ReverseMap();

            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Birthdate, opt => opt.ConvertUsing(new DateConverter(), src => src.Birthdate))
                .ForMember(dest => dest.Sex, opt => opt.ConvertUsing(new SexConverter(), src => src.Sex))
                .ReverseMap();

            CreateMap<ExamReport, ExamReportDTO>()
                .ForMember(dest => dest.Cid, opt => opt.MapFrom(src => src.Cid))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ExamRequestName, opt => opt.MapFrom(src => src.ExamRequest.ExamName))
                .ForMember(dest => dest.ExamRequestId, opt => opt.MapFrom(src => src.ExamRequest.Id))
                .ForMember(dest => dest.MedicId, opt => opt.MapFrom(src => src.Medic.Id))
                .ForMember(dest => dest.MedicName, opt => opt.MapFrom(src => src.Medic.User.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();

        }
    }
}
