using FluentValidation.Results;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using System.Collections.Generic;
using System.Linq;

namespace SGA.Domain.Validations
{
    public class RegisterNewAdoptionValidation
    {
        public static ValidationResult Validate(Adoption adoption)
        {
            if (!adoption.GetAdoptions().Any())
                return new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("GetAdoptions", Message.MS_008)
                });


            return new ValidationResult();
        }
    }
}