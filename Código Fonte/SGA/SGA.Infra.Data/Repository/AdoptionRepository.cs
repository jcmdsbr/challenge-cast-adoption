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

        public IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions()
        {
            return Db.Set<Responsible>().Select(x => new AdoptionDto(x, DbSet.Count(a=>a.ResponsibleId == x.Id)));
        }
    }
}