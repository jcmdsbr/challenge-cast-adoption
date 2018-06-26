using SGA.Domain.Entities.Core;
using System;

namespace SGA.Domain.Entities.Models
{
    public class TypePet : Entity
    {
        public TypePet(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        protected TypePet() { }

        public string Description { get; private set; }
    }
}
