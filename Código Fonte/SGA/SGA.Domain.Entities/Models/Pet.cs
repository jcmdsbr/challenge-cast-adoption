using System;
using SGA.Domain.Entities.Core;

namespace SGA.Domain.Entities.Models
{
    public class Pet : Entity
    {
        public Pet(Guid id,string name, string description, TypePet typePet)
        {
            Id = id;
            Name = name;
            Description = description;
            TypePet = typePet;
            TypePetId = typePet.Id;
        }

        protected Pet() { }

        public string Name { get; private set; }

        public string Description { get; private set; }
        public  TypePet TypePet { get; private set; }

        public Guid TypePetId { get; private set; }


    }
}
