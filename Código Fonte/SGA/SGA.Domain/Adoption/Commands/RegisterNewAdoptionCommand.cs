using SGA.Application.Domain.Adoption;
using SGA.Application.Repository.Adoption;
using SGA.Application.Repository.Core;
using SGA.Domain.Adoption.Validations;
using SGA.Domain.Core;
using System.Linq;
using Model = SGA.Domain.Entities.Models;

namespace SGA.Domain.Adoption.Commands
{
    public class RegisterNewAdoptionCommand : Command<Model.Adoption>, IRegisterNewAdoptionCommand
    {
        private readonly IAdoptionRepository _adotionRepository;

        public RegisterNewAdoptionCommand(IAdoptionRepository adotionRepository, IUnitOfWork uow) : base(uow)
        {
            _adotionRepository = adotionRepository;
        }

        public override void Execute(Model.Adoption obj)
        {
            var validation = RegisterNewAdoptionValidation.Validate(obj);

            if (!validation.IsValid)
            {
                AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
                return;
            }

            _adotionRepository.AddRange(obj.GetAdoptions());

            Commit();

        }
    }
}