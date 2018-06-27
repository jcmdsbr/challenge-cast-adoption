using System;
using System.Collections.Generic;

namespace SGA.Domain.Entities.Models
{
    public class Adoption
    {
        private readonly List<Adoption> _adoptions = new List<Adoption>();

        public Adoption(Pet pet, Responsible responsible, DateTime dateAdoption)
        {
            Pet = pet;
            Responsible = responsible;
            DateAdoption = dateAdoption;
            PetId = pet.Id;
            ResponsibleId = responsible.Id;
        }

        public Adoption(Guid pet, Guid responsible)
        {
            PetId = pet;
            ResponsibleId = responsible;
        }

        public Adoption() { }

        public Guid PetId { get; private set; }

        public Guid ResponsibleId { get; private set; }
        public Pet Pet { get; private set; }
        public Responsible Responsible { get; private set; }
        public DateTime DateAdoption { get; private set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Adoption;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return PetId.Equals(compareTo.PetId) && ResponsibleId.Equals(compareTo.ResponsibleId);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + PetId.GetHashCode() + ResponsibleId.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + PetId.GetHashCode() + ResponsibleId.GetHashCode() + "]";
        }

        public void AddAdoption(Adoption adoption)
        {
            _adoptions.Add(adoption);
        }

        public List<Adoption> GetAdoptions()
        {
            return _adoptions;
        }


    }
}
