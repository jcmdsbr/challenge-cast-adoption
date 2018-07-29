using SGA.Domain.Entities.Models;
using System;

namespace SGA.Infra.Dapper.Maps
{
    public static class PetMap
    {
        public static Func<Pet, TypePet, Pet> FullPet()
        {
            return (p, t) =>
            {
                p.SetTypePet(t);

                return p;
            };
        }
    }
}