using SGA.Domain.Entities.Models;

namespace SGA.Domain.Validations
{
    public class RegisterNewPetValidation : PetValidation<Pet>

    {
        public RegisterNewPetValidation()
        {
            ValidateName();
            ValidateDescription();
            // ValidateType();
        }
    }
}