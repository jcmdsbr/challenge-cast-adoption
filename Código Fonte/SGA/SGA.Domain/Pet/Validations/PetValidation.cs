using System;
using FluentValidation;
using SGA.Infra.CrossCutting.Messages;

namespace SGA.Domain.Pet.Validations
{
    public abstract class PetValidation<T> : AbstractValidator<T> where T : Entities.Models.Pet
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(string.Format(Message.MS_002, "Nome"))
                .Length(2, 10).WithMessage(string.Format(Message.MS_005, "Nome", 2, 10));
        }

        protected void ValidateType()
        {
            RuleFor(c => c.TypePet)
                .NotNull().WithMessage(string.Format(Message.MS_002, "Tipo do Pet"));
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(string.Format(Message.MS_002, "Descrição"))
                .Length(10, 100).WithMessage(string.Format(Message.MS_005, "Descrição", 10, 100));
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage(string.Format(Message.MS_002, "Código"));
        }
    }
}