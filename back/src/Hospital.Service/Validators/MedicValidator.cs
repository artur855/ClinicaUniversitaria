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

            
            RuleFor(m => m.CRM)
                .NotEmpty().WithMessage("CRM obrigatório");

        }
    }
}
