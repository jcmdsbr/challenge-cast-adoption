using SGA.UI.Site.Helpers;

namespace SGA.UI.Site.Models
{
    public class UserViewModel
    {
        [RequiredCustom("Usuário")]
        public string Username { get; set; }

        [RequiredCustom("Senha")]
        public string Password { get; set; }
    }
}
