using System.Linq;
using SGA.Application.Domain.Pet;
using SGA.Application.Repository.Pet;
using SGA.Domain.Core;
using SGA.Domain.Pet.Validations;

namespace SGA.Domain.Pet.Commands
{
    public class RegisterNewPetCommand : Command<Entities.Models.Pet>, IRegisterNewAnimalCommand
    {
        private readonly IPetRepository _petRepository;

        public RegisterNewPetCommand(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public override void Execute(Entities.Models.Pet pet)
        {
            var validation = new RegisterNewPetValidation().Validate(pet);

            if (validation.IsValid)
            {
                pet.CreateNewId();

                _petRepository.Add(pet);

                return;
            }

            AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}