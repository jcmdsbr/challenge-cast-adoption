namespace SGA.Domain.Responsible.Validations
{
    public class RegisterNewResponsibleValidation : ResponsibleValidation<Entities.Models.Responsible>
    {
        public RegisterNewResponsibleValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateCpf();
        }
    }
}