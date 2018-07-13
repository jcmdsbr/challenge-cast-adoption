using Newtonsoft.Json;
using SGA.Application.Domain.Dtos;
using SGA.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGA.Application.UI.Models
{
    public class AdoptionViewModel
    {
        public ResponsibleViewModel Responsible { get; set; }
        public int AdoptedPets { get; set; }

        public string PetsJson { get; set; }

        public List<Guid> Pets => JsonConvert.DeserializeObject<List<Guid>>(PetsJson);

        public AdoptionViewModel()
        {

        }

        public AdoptionViewModel(ResponsibleViewModel responsible, int adoptedPets)
        {
            Responsible = responsible;
            AdoptedPets = adoptedPets;
        }
        public static explicit operator AdoptionViewModel(AdoptionDto model)
        {

            if (model == null)
                return null;

            return new AdoptionViewModel((ResponsibleViewModel)model.Responsible, model.AdoptedPets);
        }

        public static implicit operator Adoption(AdoptionViewModel model)
        {

            if (model == null)
                return null;

            var adoption = new Adoption();

            if (model.Pets.Any())
                model.Pets.ForEach(x => adoption.AddAdoption(new Adoption(x, model.Responsible.Id)));

            return adoption;
        }
    }
}
