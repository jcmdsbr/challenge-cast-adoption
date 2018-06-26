using SGA.Application.Domain.Core;
using SGA.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;

namespace SGA.Application.Domain.Adoption
{
    public interface IAdoptionQuery : IQuery<SGA.Domain.Entities.Models.Adoption>
    {
        IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions();
    }
}