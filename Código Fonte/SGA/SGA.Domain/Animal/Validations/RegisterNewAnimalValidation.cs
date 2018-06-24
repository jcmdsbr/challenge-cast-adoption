namespace SGA.Domain.Animal.Validations
{
    public class RegisterNewAnimalValidation : AnimalValidation<Entities.Models.Animal>

    {
        public RegisterNewAnimalValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateType();
        }
    }
}