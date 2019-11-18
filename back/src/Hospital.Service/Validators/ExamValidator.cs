using FluentValidation;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Validators
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(e => e.ExamRequestId).NotNull().WithMessage("O id do pedido de exame não pode ser nulo");
            RuleFor(e => e.Date).NotNull().WithMessage("A data do exame tem que ser preenchida");
            RuleFor(e => e.ExamPath).NotNull().WithMessage("O caminho para o arquivo do exame não pode ser nulo");
        }
    }
}
