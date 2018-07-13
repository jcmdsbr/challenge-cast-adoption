using SGA.Application.Core;
using SGA.Application.Domain.Dtos;
using SGA.Domain.Entities.Models;
using System;
using System.Collections.Generic;

namespace SGA.Application.Domain.Queries
{
    public interface IAdoptionQuery : IQuery<Adoption>
    {
        IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions();
        AdoptionDto FindReponsableAndTheirAdoptionsBy(Guid id);
    }
}