using System.Linq;
using SGA.Application.Domain.Animal;
using SGA.Application.Repository.Animal;
using SGA.Domain.Animal.Validations;
using SGA.Domain.Core;

namespace SGA.Domain.Animal.Commands
{
    public class RegisterNewAnimalCommand : Command<Entities.Models.Animal>, IRegisterNewAnimalCommand
    {
        private readonly IAnimalRepository _animalRepository;

        public RegisterNewAnimalCommand(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public override void Execute(Entities.Models.Animal animal)
        {
            var validation = new RegisterNewAnimalValidation().Validate(animal);

            if (validation.IsValid)
            {
                animal.CreateNewId();

                _animalRepository.Add(animal);

                return;
            }

            AddErros(validation.Errors.Select(x=>x.ErrorMessage).ToList());
           
        }
    }
}