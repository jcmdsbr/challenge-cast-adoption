using SGA.Application.Domain.Pet;
using SGA.Application.Repository.Core;
using SGA.Application.Repository.Pet;
using SGA.Domain.Core;
using SGA.Domain.Pet.Validations;
using System.Linq;
using Model = SGA.Domain.Entities.Models;

namespace SGA.Domain.Pet.Commands
{
    public class RegisterNewPetCommand : Command<Model.Pet>, IRegisterNewPetCommand
    {
        private readonly IPetRepository _petRepository;

        public RegisterNewPetCommand(IPetRepository petRepository, IUnitOfWork uow)
            : base(uow)
        {
            _petRepository = petRepository;
        }

        public override void Execute(Model.Pet obj)
        {
            var validation = new RegisterNewPetValidation().Validate(obj);

            if (!validation.IsValid)
            {
                AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
                return;
            }

            obj.CreateNewId();

            _petRepository.Add(obj);

            Commit();
        }
    }
}