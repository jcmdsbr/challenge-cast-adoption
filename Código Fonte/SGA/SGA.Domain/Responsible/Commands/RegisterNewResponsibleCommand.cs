using System.Linq;
using SGA.Application.Domain.Responsible;
using SGA.Application.Repository.Responsible;
using SGA.Domain.Core;
using SGA.Domain.Responsible.Validations;

namespace SGA.Domain.Responsible.Commands
{
    public class RegisterNewResponsibleCommand : Command<Entities.Models.Responsible>, IRegisterNewResponsibleCommand
    {
        private readonly IResponsibleRepository _responsibleRepository;

        public RegisterNewResponsibleCommand(IResponsibleRepository responsibleRepository)
        {
            _responsibleRepository = responsibleRepository;
        }

        public override void Execute(Entities.Models.Responsible responsible)
        {
            var validation = new RegisterNewResponsibleValidation().Validate(responsible);

            if (validation.IsValid)
            {
                responsible.CreateNewId();

                _responsibleRepository.Add(responsible);

                return;
            }

            AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}