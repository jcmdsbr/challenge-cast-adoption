using System;
using System.Collections.Generic;
using System.Text;
using SGA.Domain.Entities.Core;

namespace SGA.Domain.Entities.ValueObjects
{
    public class Cpf : ValueObject<Cpf>
    {
        protected Cpf()
        {
        }

        public Cpf(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }


        protected override bool EqualsCore(Cpf other)
        {
            return Value == other.Value;
        }


        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
