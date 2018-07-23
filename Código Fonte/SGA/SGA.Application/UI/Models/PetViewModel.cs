using SGA.Application.UI.Helpers;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGA.Application.UI.Models
{
    public class PetViewModel
    {
        public PetViewModel(Guid id, string description, string name, Guid typePetId, string typePetDescription)
        {
            Id = id;
            Description = description;
            Name = name;
            TypePetId = typePetId;
            TypePetDescription = typePetDescription;
        }

        public PetViewModel()
        {
        }

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


        [DisplayName("Tipo do Animal")] public string TypePetDescription { get; set; }


        public static implicit operator Pet(PetViewModel model)
        {
            if (model == null)
                return null;

            return new Pet(model.Id, model.Name, model.Description, model.TypePetId);
        }

        public static explicit operator PetViewModel(Pet pet)
        {
            if (pet == null)
                return null;

            return new PetViewModel(pet.Id, pet.Name, pet.Description, pet.TypePetId, pet.TypePet.Description);
        }
    }
}