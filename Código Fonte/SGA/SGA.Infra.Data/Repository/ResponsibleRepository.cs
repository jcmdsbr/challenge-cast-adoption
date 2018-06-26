using SGA.Application.Domain.Responsible;
using SGA.Application.Repository.Responsible;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.Repository
{
    public class ResponsibleRepository : BaseRepository<Responsible>, IResponsibleQuery, IResponsibleRepository
    {
        public ResponsibleRepository(SgaContext db) : base(db)
        {
        }
    }
}