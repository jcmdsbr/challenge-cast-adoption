using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SGA.Infra.CrossCutting.Messages;
using SGA.UI.Site.Helpers;

namespace SGA.UI.Site.Models
{
    public class ResponsibleViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = Message.MS_002)]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = Message.MS_002)]
        [EmailAddress(ErrorMessage = Message.MS_007)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = Message.MS_002)]
        [Cpf(Message.MS_007)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
    }
}