using SGA.Application.Repository;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;
using System.Collections.Generic;

namespace SGA.Infra.Repository.Repository
{
    public class AdoptionRepository : BaseRepository<Adoption>, IAdoptionRepository
    {
        public AdoptionRepository(SgaContext db) : base(db)
        {
        }

        public void AddRange(List<Adoption> adoptions)
        {
            DbSet.AddRange(adoptions);
        }
    }
}