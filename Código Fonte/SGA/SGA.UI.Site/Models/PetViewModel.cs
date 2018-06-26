using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using SGA.UI.Site.Helpers;

namespace SGA.UI.Site.Models
{
    public class PetViewModel
    {
        [Key] public Guid Id { get; set; }

        [RequiredCustom("Descrição")]
        [LengthValidation(10, 100, "Descrição")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [RequiredCustom("Nome")]
        [LengthValidation(2, 10, "Descrição")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Tipo do Animal")]
        [Required(ErrorMessage = Message.MS_002)]
        public Guid TypePetId { get; set; }

        public static implicit operator Pet(PetViewModel model)
        {

            if (model == null)
                return null;

            return new Pet(model.Id, model.Name,model.Description,model.TypePetId);
        }
    }

}