using System;
using SGA.Domain.Entities.Core;

namespace SGA.Domain.Entities.Models
{
    public class Animal : Entity
    {
        public Animal(Guid id,string name, string description, TypeAnimal typeAnimal)
        {
            Id = id;
            Name = name;
            Description = description;
            TypeAnimal = typeAnimal;
        }

        protected Animal() { }

        public string Name { get; private set; }

        public string Description { get; private set; }
        public  virtual TypeAnimal TypeAnimal { get; private set; }
    }
}
