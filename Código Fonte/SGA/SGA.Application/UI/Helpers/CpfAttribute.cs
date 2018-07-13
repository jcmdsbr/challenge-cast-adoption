using SGA.Infra.CrossCutting.Validations;
using System.ComponentModel.DataAnnotations;

namespace SGA.Application.UI.Helpers
{
    public class CpfAttribute : ValidationAttribute
    {
        public CpfAttribute(string erroMessage)
        {
            ErrorMessage = erroMessage;
        }
        public override bool IsValid(object value)
        {
            var cpf = (string)value;

            return CpfValidator.IsValid(cpf);
        }
    }
}
