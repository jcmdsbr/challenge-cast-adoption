using SGA.Domain.Entities.Core;
using System;

namespace SGA.Domain.Entities.Models
{
    public class TypeAnimal : Entity
    {
        public TypeAnimal(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        protected TypeAnimal() { }

        public string Description { get; private set; }
    }
}
