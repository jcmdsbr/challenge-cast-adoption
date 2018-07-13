using SGA.Application.Core;
using SGA.Application.Domain.Commands;
using SGA.Application.Repository;
using SGA.Domain.Commands.Core;
using SGA.Domain.Entities.Models;
using SGA.Domain.Validations;
using System.Linq;

namespace SGA.Domain.Commands
{
    public class RegisterNewPetCommand : Command<Pet>, IRegisterNewPetCommand
    {
        private readonly IPetRepository _petRepository;

        public RegisterNewPetCommand(IPetRepository petRepository, IUnitOfWork uow)
            : base(uow)
        {
            _petRepository = petRepository;
        }

        public override void Execute(Pet pet)
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