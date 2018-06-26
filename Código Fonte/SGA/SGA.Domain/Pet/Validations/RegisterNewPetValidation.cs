namespace SGA.Domain.Pet.Validations
{
    public class RegisterNewPetValidation : PetValidation<Entities.Models.Pet>

    {
        public RegisterNewPetValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateType();
        }
    }
}