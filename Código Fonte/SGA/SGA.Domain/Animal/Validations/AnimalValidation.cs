using System;
using FluentValidation;
using SGA.Infra.CrossCutting.Messages;

namespace SGA.Domain.Animal.Validations
{
    public abstract class AnimalValidation<T> : AbstractValidator<T> where T : Entities.Models.Animal
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(string.Format(Message.MsRequired, "Nome"))
                .Length(2, 10).WithMessage(string.Format(Message.MsRange, "Nome", 2, 10));
        }

        protected void ValidateType()
        {
            RuleFor(c => c.TypeAnimal)
                .NotNull().WithMessage(string.Format(Message.MsRequired, "Tipo do Animal"));
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(string.Format(Message.MsRequired, "Descrição"))
                .Length(10, 100).WithMessage(string.Format(Message.MsRange, "Descrição", 10, 100));
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage(string.Format(Message.MsRequired, "Código"));
        }
    }
}