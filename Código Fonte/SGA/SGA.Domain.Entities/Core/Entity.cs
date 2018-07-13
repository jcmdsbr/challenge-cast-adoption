using Dapper.Contrib.Extensions;
using System;

namespace SGA.Domain.Entities.Core
{
    public abstract class Entity
    {
        [ExplicitKey]
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        public virtual void CreateNewId()
        {
            Id = Guid.NewGuid();
        }
    }
}
