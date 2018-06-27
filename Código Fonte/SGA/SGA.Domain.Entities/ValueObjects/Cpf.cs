using System;
using System.Collections.Generic;
using System.Text;
using SGA.Domain.Entities.Core;
using SGA.Infra.CrossCutting.Extensions;

namespace SGA.Domain.Entities.ValueObjects
{
    public class Cpf : ValueObject<Cpf>
    {
        protected Cpf()
        {
        }

        public Cpf(string value)
        {
            Value = value.UnMaskCpf();
        }

        public string Value { get; private set; }


        protected override bool EqualsCore(Cpf other)
        {
            return Value == other.Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public  string Format => Convert.ToUInt64(Value).ToString(@"000\.000\.000\-00"); 
        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
