using System.Linq;
using SGA.Application.Domain.Responsible;
using SGA.Application.Repository.Adoption;
using SGA.Domain.Adoption.Validations;
using SGA.Domain.Core;

namespace SGA.Domain.Adoption.Commands
{
    public class RegisterNewAdoptionCommand : Command<Entities.Models.Adoption>
    {
        private readonly IAdotionRepository _adotionRepository;

        public RegisterNewAdoptionCommand(IAdotionRepository adotionRepository)
        {
            _adotionRepository = adotionRepository;
        }

        public override void Execute(Entities.Models.Adoption adoption)
        {
            var validation = new RegisterNewAdoptionValidation().Validate(adoption);

            if (validation.IsValid)
            {
                _adotionRepository.Add(adoption);
                return;
            }

            AddErros(validation.Errors.Select(x=>x.ErrorMessage).ToList());
           
        }
    }
}