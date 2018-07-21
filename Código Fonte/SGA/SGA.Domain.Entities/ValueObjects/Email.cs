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
            Address = value;
        }

        public override string ToString()
        {
            return Address;
        }

        public string Address { get; private set; }

        protected override bool EqualsCore(Email other)
        {
            return Address == other.Address;
        }

        protected override int GetHashCodeCore()
        {
            return Address.GetHashCode();
        }
    }
}
