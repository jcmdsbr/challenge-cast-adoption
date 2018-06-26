using SGA.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Domain.Entities.Dtos
{
    public class AdoptionDto
    {
        public AdoptionDto()
        {

        }

        public AdoptionDto(Responsible responsible, int adoptedPets)
        {
            Responsible = responsible;
            AdoptedPets = adoptedPets;
        }

        public Responsible  Responsible { get; set; }

        public int AdoptedPets { get; set; }
    }
}
