using System.Collections.Generic;
using FluentValidation.Results;
using SGA.Domain.Pet.Validations;
using SGA.Domain.Responsible.Validations;

namespace SGA.Domain.Adoption.Validations
{
    public class RegisterNewAdoptionValidation
    {
        public ValidationResult Validate(Entities.Models.Adoption adoption)
        {
            var resposibleValidation = new RegisterNewResponsibleValidation().Validate(adoption.Responsible);
            var petValidation = new RegisterNewPetValidation().Validate(adoption.Pet);
            var failures = new List<ValidationFailure>();

            failures.AddRange(resposibleValidation.Errors);
            failures.AddRange(petValidation.Errors);

            return new ValidationResult(failures);
        }
    }
}