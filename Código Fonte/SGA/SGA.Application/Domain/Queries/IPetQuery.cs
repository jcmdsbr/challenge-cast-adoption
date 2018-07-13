using SGA.Application.Core;
using SGA.Domain.Entities.Models;
using System.Collections.Generic;

namespace SGA.Application.Domain.Queries
{
    public interface IPetQuery : IQuery<Pet>
    {
        IEnumerable<TypePet> GetTypePets();
        IEnumerable<Pet> GetPetsNotAdopted();
    }
}