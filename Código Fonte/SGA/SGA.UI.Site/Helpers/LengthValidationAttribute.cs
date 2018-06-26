using SGA.Infra.CrossCutting.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGA.UI.Site.Helpers
{
    public sealed class LengthValidationAttribute : ValidationAttribute
    {
        private int _minLength;
        private int _maxLength;

        public LengthValidationAttribute(int minLength, int maxLength, string name)
        {
            _minLength = minLength;
            _maxLength = maxLength;

            ErrorMessage = string.Format(Message.MS_005, name, minLength, maxLength);
        }

        public override bool IsValid(object value)
        {
            var val = value as string;

            return !(!string.IsNullOrEmpty(val) && (val.Length < _minLength || val.Length > _maxLength));
        }
    }
}
