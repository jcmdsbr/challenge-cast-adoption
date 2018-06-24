using System;
using FluentValidation;
using SGA.Infra.CrossCutting.Messages;
using SGA.Infra.CrossCutting.Validations;

namespace SGA.Domain.Responsible.Validations
{
    public abstract class ResponsibleValidation<T> : AbstractValidator<T> where T : Entities.Models.Responsible
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(string.Format(Message.MsRequired, "Nome"))
                .Length(3, 50).WithMessage(string.Format(Message.MsRange, "Nome", 3, 50));
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Description)
                .NotEmpty().WithMessage(string.Format(Message.MsRequired, "Email"))
                .EmailAddress().WithMessage(Message.MsEmail);
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.Cpf.Value)
                .NotEmpty().WithMessage(string.Format(Message.MsRequired, "Cpf"))
                .Must(IsValidCpf)
                .WithMessage(Message.MsCpfInvalid);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage(string.Format(Message.MsRequired, "Código"));
        }

        protected static bool IsValidCpf(string value)
        {
            return CpfValidator.IsValid(value);
        }
    }
}