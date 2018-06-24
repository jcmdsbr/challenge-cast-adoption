using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SGA.Application.Repository.Animal;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.Repository
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalQuery, IAnimalRepository
    {
        public AnimalRepository(SgaContext db) : base(db)
        {
        }

        public ICollection<TypeAnimal> GetTypeAnimals()
        {
            return Db.Set<TypeAnimal>().AsNoTracking().ToList();
        }
    }
}