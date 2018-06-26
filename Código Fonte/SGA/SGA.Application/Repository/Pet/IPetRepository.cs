using SGA.Application.Repository.Core;

namespace SGA.Application.Repository.Pet
{
    public interface IPetRepository : IRepository<SGA.Domain.Entities.Models.Pet>
    {
    }
}