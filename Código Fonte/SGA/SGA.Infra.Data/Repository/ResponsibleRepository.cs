using SGA.Application.Repository;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.Repository
{
    public class ResponsibleRepository : BaseRepository<Responsible>, IResponsibleRepository
    {
        public ResponsibleRepository(SgaContext db) : base(db)
        {
        }
    }
}