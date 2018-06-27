using SGA.Application.Repository.Core;
using System.Collections.Generic;

namespace SGA.Application.Repository.Adoption
{
    public interface IAdoptionRepository : IRepository<SGA.Domain.Entities.Models.Adoption>
    {
        void AddRange(List<SGA.Domain.Entities.Models.Adoption> adoptions);
    }
}