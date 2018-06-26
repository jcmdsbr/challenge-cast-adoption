using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SGA.Application.Domain.Pet;
using SGA.Application.Repository.Pet;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.Repository
{
    public class PetRepository : BaseRepository<Pet>, IPetQuery, IPetRepository
    {
        public PetRepository(SgaContext db) : base(db)
        {
        }

        public ICollection<TypePet> GetTypeAnimals()
        {
            return Db.Set<TypePet>().AsNoTracking().ToList();
        }

        public ICollection<Pet> GetPetsNotAdopted()
        {
            var query = DbSet.AsNoTracking()
                .Include(x => x.TypePet)
                .Where(x=> !Db.Set<Adoption>().Any(a=>a.PetId == x.Id));

            return query.ToList();

        }
    }
}