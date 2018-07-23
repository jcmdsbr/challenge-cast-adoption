using SGA.Domain.Entities.Models;

namespace SGA.Application.Domain.Dtos
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

        public Responsible Responsible { get; set; }

        public int AdoptedPets { get; set; }
    }
}