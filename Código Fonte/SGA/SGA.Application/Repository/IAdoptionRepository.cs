using SGA.Application.Core;
using SGA.Domain.Entities.Models;
using System.Collections.Generic;

namespace SGA.Application.Repository
{
    public interface IAdoptionRepository : IRepository<Adoption>
    {
        void AddRange(List<Adoption> adoptions);
    }
}