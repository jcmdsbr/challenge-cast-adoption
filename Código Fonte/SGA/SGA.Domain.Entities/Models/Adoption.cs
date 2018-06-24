using SGA.Domain.Entities.Core;
using System;

namespace SGA.Domain.Entities.Models
{
    public class Adoption 
    {
        public Adoption(Animal animal, Responsible responsible, DateTime dateAdoption)
        {
            Animal = animal;
            Responsible = responsible;
            DateAdoption = dateAdoption;
            AnimalId = animal.Id;
            ResponsibleId = responsible.Id;
        }

        protected Adoption() {  }

        public Guid AnimalId { get; private set; }

        public Guid ResponsibleId { get; private set; }
        public  Animal Animal { get; private set; }
        public  Responsible Responsible { get; private set; }
        public DateTime DateAdoption { get; private set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Adoption;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return AnimalId.Equals(compareTo.AnimalId) && ResponsibleId.Equals(compareTo.ResponsibleId);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + AnimalId.GetHashCode() + ResponsibleId.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + AnimalId.GetHashCode() + ResponsibleId.GetHashCode() + "]";
        }

    }
}
