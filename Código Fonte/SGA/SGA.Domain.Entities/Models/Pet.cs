using Dapper.Contrib.Extensions;
using SGA.Domain.Entities.Core;
using System;

namespace SGA.Domain.Entities.Models
{
    [Table("animal")]
    public class Pet : Entity
    {
        public Pet(Guid id, string name, string description, TypePet typePet)
        {
            Id = id;
            Name = name;
            Description = description;
            TypePet = typePet;
            TypePetId = typePet.Id;
        }

        public Pet(Guid id, string name, string description, Guid typePetId)
        {
            Id = id;
            Name = name;
            Description = description;
            TypePetId = typePetId;
        }

        public Pet() { }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public TypePet TypePet { get; private set; }

        public Guid TypePetId { get; private set; }

        public void SetTypePet(TypePet typePet)
        {
            TypePet = typePet;
        }

    }
}
