using System;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Service.Validators
{
    public class ExamReportValidator : AbstractValidator<ExamReport>
    {
        public ExamReportValidator()
        {
            RuleFor(er => er.MedicId)
                .NotEmpty()
                .WithMessage("ExamReport residente invalido");
            
            RuleFor(er => er.ExamRequestId)
                .NotEmpty()
                .WithMessage("ExamReport pedido de exame invalido");
            
            RuleFor(er => er.Cid)
                .NotEmpty()
                .WithMessage("ExamReport cid invalido");
        }
    }
}