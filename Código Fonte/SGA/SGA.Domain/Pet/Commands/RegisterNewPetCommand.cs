using System.Linq;
using SGA.Application.Domain.Pet;
using SGA.Application.Repository.Core;
using SGA.Application.Repository.Pet;
using SGA.Domain.Core;
using SGA.Domain.Pet.Validations;

namespace SGA.Domain.Pet.Commands
{
    public class RegisterNewPetCommand : Command<Entities.Models.Pet>, IRegisterNewPetCommand
    {
        private readonly IPetRepository _petRepository;

        public RegisterNewPetCommand(IPetRepository petRepository, IUnitOfWork uow)
            : base(uow)
        {
            _petRepository = petRepository;
        }

        public override void Execute(Entities.Models.Pet pet)
        {
            var validation = new RegisterNewPetValidation().Validate(pet);

            if (!validation.IsValid)
            {
                AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
                return;
            }

            pet.CreateNewId();

            _petRepository.Add(pet);

            Commit();
        }
    }
}