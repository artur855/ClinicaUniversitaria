using System;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Service.Validators
{
    public class ExamRequestValidator: AbstractValidator<ExamRequest>
    {
        public ExamRequestValidator()
        {
            
            RuleFor(er => er.MedicId)
                .NotEmpty()
                .WithMessage("ExamRequest medico invalido");
            
            RuleFor(er => er.PatientId)
                .NotEmpty()
                .WithMessage("ExamRequest paciente invalido");
            
            RuleFor(er => er.ExpectedDate)
                .NotEmpty()
                .WithMessage("ExamRequest data invalida");

            RuleFor(er => er.ExpectedDate)
                .LessThan(DateTime.Now)
                .WithMessage("Exame marcado em data inválida");
        }
    }
}