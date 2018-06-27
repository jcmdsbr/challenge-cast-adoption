using SGA.Application.Domain.Adoption;
using SGA.Application.Repository.Adoption;
using SGA.Application.Repository.Core;
using SGA.Domain.Adoption.Validations;
using SGA.Domain.Core;
using System.Linq;

namespace SGA.Domain.Adoption.Commands
{
    public class RegisterNewAdoptionCommand : Command<Entities.Models.Adoption>, IRegisterNewAdoptionCommand
    {
        private readonly IAdoptionRepository _adotionRepository;

        public RegisterNewAdoptionCommand(IAdoptionRepository adotionRepository, IUnitOfWork uow) : base(uow)
        {
            _adotionRepository = adotionRepository;
        }

        public override void Execute(Entities.Models.Adoption adoption)
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