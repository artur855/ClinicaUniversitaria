using FluentValidation;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user)
                .NotNull()
                .WithMessage("Objeto Nulo");

            RuleFor(user => user.Email)
                .EmailAddress()
                .WithMessage("Usuário sem e-mail");

            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Senha inválida");
        }
    }
}
