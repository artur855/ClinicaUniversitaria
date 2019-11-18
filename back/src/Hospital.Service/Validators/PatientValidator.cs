using System;
using System.Data;
using System.Runtime.ExceptionServices;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Service.Validators
{
    public class PatientValidator: AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient).NotEmpty().WithMessage("Objeto nulo");
            RuleFor(patient => patient.Birthdate).NotEmpty().WithMessage("Paciente sem data de nascimento");
            RuleFor(patient => patient.Birthdate).LessThan(DateTime.Now).WithMessage("Não é possivel cadastrar pacientes ainda não nascidos");
            RuleFor(patient => patient.Color).NotEmpty().WithMessage("Paciente sem cor"); 
            RuleFor(patient => patient.Sex).NotEmpty().WithMessage("Paciente sem sexo");
        }
    }
}