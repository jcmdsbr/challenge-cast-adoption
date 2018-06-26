using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SGA.Infra.CrossCutting.Validations;

namespace SGA.UI.Site.Helpers
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
