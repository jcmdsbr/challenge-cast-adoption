using SGA.Application.UI.Helpers;

namespace SGA.Application.UI.Models
{
    public class UserViewModel
    {
        [RequiredCustom("Usuário")] public string Username { get; set; }

        [RequiredCustom("Senha")] public string Password { get; set; }
    }
}