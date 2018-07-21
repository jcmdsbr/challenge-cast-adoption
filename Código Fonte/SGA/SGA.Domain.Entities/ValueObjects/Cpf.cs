using SGA.Domain.Entities.Core;
using SGA.Infra.CrossCutting.Extensions;
using System;

namespace SGA.Domain.Entities.ValueObjects
{
    public class Cpf : ValueObject<Cpf>
    {
        protected Cpf()
        {
        }

        public Cpf(string value)
        {
            Number = value.UnMaskCpf();
        }

        public string Number { get; protected set; }


        protected override bool EqualsCore(Cpf other)
        {
            return Number == other.Number;
        }

        public override string ToString()
        {
            return Number;
        }

        public string Format => Convert.ToUInt64(Number).ToString(@"000\.000\.000\-00");
        protected override int GetHashCodeCore()
        {
            return Number.GetHashCode();
        }
    }
}
