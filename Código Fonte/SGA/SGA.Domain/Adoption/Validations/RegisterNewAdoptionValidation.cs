using System.Collections.Generic;
using FluentValidation.Results;
using SGA.Domain.Animal.Validations;
using SGA.Domain.Responsible.Validations;

namespace SGA.Domain.Adoption.Validations
{
    public class RegisterNewAdoptionValidation
    {
        public ValidationResult Validate(Entities.Models.Adoption adoption)
        {
            var resposibleValidation = new RegisterNewResponsibleValidation().Validate(adoption.Responsible);
            var animalValidation = new RegisterNewAnimalValidation().Validate(adoption.Animal);
            var failures = new List<ValidationFailure>();

            failures.AddRange(resposibleValidation.Errors);
            failures.AddRange(animalValidation.Errors);

            return new ValidationResult(failures);
        }
    }
}