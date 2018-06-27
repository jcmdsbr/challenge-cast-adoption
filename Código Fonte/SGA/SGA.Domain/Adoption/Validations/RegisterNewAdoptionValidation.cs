using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace SGA.Domain.Adoption.Validations
{
    public class RegisterNewAdoptionValidation
    {
        public static ValidationResult Validate(Entities.Models.Adoption adoption)
        {
            if (!adoption.GetAdoptions().Any())
                return new ValidationResult(new List<ValidationFailure> { new ValidationFailure("GetAdoptions", Infra.CrossCutting.Messages.Message.MS_008) });


            return new ValidationResult();
        }
    }
}