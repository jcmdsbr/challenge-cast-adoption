using SGA.Application.Core;
using SGA.Application.Domain.Commands;
using SGA.Application.Repository;
using SGA.Domain.Commands.Core;
using SGA.Domain.Entities.Models;
using SGA.Domain.Validations;
using System.Linq;

namespace SGA.Domain.Commands
{
    public class RegisterNewAdoptionCommand : Command<Adoption>, IRegisterNewAdoptionCommand
    {
        private readonly IAdoptionRepository _adotionRepository;

        public RegisterNewAdoptionCommand(IAdoptionRepository adotionRepository, IUnitOfWork uow) : base(uow)
        {
            _adotionRepository = adotionRepository;
        }

        public override void Execute(Adoption adoption)
        {
            var validation = RegisterNewAdoptionValidation.Validate(adoption);

            if (!validation.IsValid)
            {
                AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
                return;
            }

            _adotionRepository.AddRange(adoption.GetAdoptions());

            Commit();
        }
    }
}