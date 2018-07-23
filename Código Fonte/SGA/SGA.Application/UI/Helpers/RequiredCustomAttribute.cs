using SGA.Infra.CrossCutting.Messages;
using System.ComponentModel.DataAnnotations;

namespace SGA.Application.UI.Helpers
{
    public sealed class RequiredCustomAttribute : RequiredAttribute
    {
        public RequiredCustomAttribute(string name)
        {
            ErrorMessage = string.Format(Message.MS_002, name);
        }
    }
}