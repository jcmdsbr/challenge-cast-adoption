using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using SGA.UI.Site.Helpers;

namespace SGA.UI.Site.Models
{
    public class ResponsibleViewModel
    {
        public ResponsibleViewModel()
        {

        }
        public ResponsibleViewModel(Guid id, string name, string email,string cpf)
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
        [Cpf(Message.MS_007)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        public static implicit operator Responsible (ResponsibleViewModel model)
        {

            if (model == null)
                return null;

            return new Responsible(model.Id, model.Name, model.Cpf, model.Email);
        }


        public static explicit operator ResponsibleViewModel(Responsible model)
        {

            if (model == null)
                return null;

            return new ResponsibleViewModel(model.Id, model.Name, model.Email.ToString(), model.Cpf.Format);
        }

    }
}