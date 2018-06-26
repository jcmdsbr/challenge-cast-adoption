using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;

namespace SGA.UI.Site.Models
{
    public class PetViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = Message.MS_002)]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = Message.MS_002)]
        [MinLength(2)]
        [MaxLength(10)]
        [DisplayName("Descrição")]
        public string Name { get; set; }

        [DisplayName("Tipo do Animal")] public SelectList TypeAnimalList { get; set; }

        [Required(ErrorMessage = Message.MS_002)]
        public TypePet TypePet { get; set; }
    }
}