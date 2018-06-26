using SGA.Infra.CrossCutting.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGA.UI.Site.Helpers
{
    public sealed class RequiredCustomAttribute : RequiredAttribute
    {
        public RequiredCustomAttribute(string name)
        {
            ErrorMessage = string.Format(Message.MS_002, name);
        }

    }
}
