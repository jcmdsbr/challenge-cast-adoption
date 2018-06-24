using SGA.Application.Repository.Adoption;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.Repository
{
    public class AdoptionRepository : BaseRepository<Adoption>, IAdotionQuery, IAdotionRepository
    {
        public AdoptionRepository(SgaContext db) : base(db)
        {
        }
    }
}