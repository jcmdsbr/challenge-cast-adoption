using System;
using System.Collections.Generic;
using System.Text;
using SGA.Domain.Entities.Core;

namespace SGA.Domain.Entities.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        protected Email()
        {
        }

        public Email(string value)
        {
            Description = value;
        }

        public override string ToString()
        {
            return Description;
        }

        public string Description { get; private set; }

        protected override bool EqualsCore(Email other)
        {
            return Description == other.Description;
        }

        protected override int GetHashCodeCore()
        {
            return Description.GetHashCode();
        }
    }
}
