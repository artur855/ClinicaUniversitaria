using FluentValidation;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Validators
{
    public class MedicValidator : AbstractValidator<Medic>
    {
        public MedicValidator()
        {
            RuleFor(medico => medico)
                .NotNull().WithMessage("adicionando null, tá sabendo legal...");

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Adicione o nome porra");

            //RuleFor(m => m.Id)
            //    .NotEmpty().WithMessage("Id necessário");

            RuleFor(m => m.CRM)
                .NotEmpty().WithMessage("CRM obrigatório");

        }
    }
}
