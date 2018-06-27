using System.Collections.Generic;
using SGA.Application.Domain.Core;
using SGA.Domain.Entities.Models;

namespace SGA.Application.Domain.Pet
{
    public interface IPetQuery : IQuery<SGA.Domain.Entities.Models.Pet>
    {
        ICollection<TypePet> GetTypePets();
        ICollection<SGA.Domain.Entities.Models.Pet> GetPetsNotAdopted();
    }
}