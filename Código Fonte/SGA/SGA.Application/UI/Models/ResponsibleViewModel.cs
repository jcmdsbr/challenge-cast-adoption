using SGA.Application.UI.Helpers;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGA.Application.UI.Models
{
    public class ResponsibleViewModel
    {
        public ResponsibleViewModel()
        {
        }

        public ResponsibleViewModel(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        [Key] public Guid Id { get; set; }

        [RequiredCustom("Nome")]
        [LengthValidation(3, 50, "Nome")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [RequiredCustom("E-mail")]
        [EmailAddress(ErrorMessage = Message.MS_007)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [RequiredCustom("Cpf")]
        [Cpf(Message.MS_006)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        public static implicit operator Responsible(ResponsibleViewModel model)
        {
            return model == null ? null : new Responsible(model.Id, model.Name, model.Cpf, model.Email);
        }


        public static explicit operator ResponsibleViewModel(Responsible model)
        {
            return model == null
                ? null
                : new ResponsibleViewModel(model.Id, model.Name, model.Email.ToString(), model.Cpf.Format);
        }
    }
}