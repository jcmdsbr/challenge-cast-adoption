using SGA.Domain.Entities.Models;

namespace SGA.Domain.Validations
{
    public class RegisterNewResponsibleValidation : ResponsibleValidation<Responsible>
    {
        public RegisterNewResponsibleValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateCpf();
        }
    }
}