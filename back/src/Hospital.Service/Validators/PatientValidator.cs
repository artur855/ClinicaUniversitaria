using System.Data;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Service.Validators
{
    public class PatientValidator: AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient).NotEmpty().WithMessage("Objeto nulo");
            RuleFor(patient => patient.Name).NotEmpty().WithMessage("Paciente sem nome");
            RuleFor(patient => patient.Birthdate).NotEmpty().WithMessage("Paciente sem data de nascimento");
            RuleFor(patient => patient.Color).NotEmpty().WithMessage("Paciente sem cor");
            RuleFor(patient => patient.Sex).NotEmpty().WithMessage("Paciente sem sexo");

        }
    }
}