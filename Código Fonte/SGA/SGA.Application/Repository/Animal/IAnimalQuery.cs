using System.Collections.Generic;
using SGA.Application.Repository.Core;
using SGA.Domain.Entities.Models;

namespace SGA.Application.Repository.Animal
{
    public interface IAnimalQuery : IQuery<SGA.Domain.Entities.Models.Animal>
    {
        ICollection<TypeAnimal> GetTypeAnimals();
    }
}