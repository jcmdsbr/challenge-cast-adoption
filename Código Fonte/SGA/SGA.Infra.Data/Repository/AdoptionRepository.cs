using SGA.Application.Domain.Adoption;
using SGA.Application.Repository.Adoption;
using SGA.Domain.Entities.Dtos;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGA.Infra.Repository.Repository
{
    public class AdoptionRepository : BaseRepository<Adoption>, IAdoptionQuery, IAdoptionRepository
    {
        public AdoptionRepository(SgaContext db) : base(db)
        {
        }

        public void AddRange(List<Adoption> adoptions)
        {
            DbSet.AddRange(adoptions);
        }

        public AdoptionDto FindReponsableAndTheirAdoptionsBy(Func<Responsible, bool> func)
        {
            return Db.Set<Responsible>().Where(func).Select(x => new AdoptionDto(x, DbSet.Count(a => a.ResponsibleId == x.Id))).Single();
        }

        public IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions()
        {
            return Db.Set<Responsible>().Select(x => new AdoptionDto(x, DbSet.Count(a => a.ResponsibleId == x.Id)));
        }
    }
}