using FluentValidation;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using SGA.Infra.CrossCutting.Validations;
using System;

namespace SGA.Domain.Validations
{
    public abstract class ResponsibleValidation<T> : AbstractValidator<T> where T : Responsible
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(string.Format(Message.MS_002, "Nome"))
                .Length(3, 50).WithMessage(string.Format(Message.MS_005, "Nome", 3, 50));
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Description)
                .NotEmpty().WithMessage(string.Format(Message.MS_002, "Email"))
                .EmailAddress().WithMessage(Message.MS_007);
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.Cpf.Value)
                .NotEmpty().WithMessage(string.Format(Message.MS_002, "Cpf"))
                .Must(IsValidCpf)
                .WithMessage(Message.MS_006);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage(string.Format(Message.MS_002, "Código"));
        }

        protected static bool IsValidCpf(string value)
        {
            return CpfValidator.IsValid(value);
        }
    }
}