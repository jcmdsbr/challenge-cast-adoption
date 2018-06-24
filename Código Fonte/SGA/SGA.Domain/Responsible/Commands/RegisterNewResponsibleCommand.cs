using SGA.Application.Domain.Responsible;
using SGA.Domain.Core;
using SGA.Domain.Responsible.Validations;

namespace SGA.Domain.Responsible.Commands
{
    public class RegisterNewResponsibleCommand : Command<Entities.Models.Responsible>, IRegisterNewResponsibleCommand
    {
        public override void Execute(Entities.Models.Responsible responsible)
        {
            var validation = new RegisterNewResponsibleValidation().Validate(responsible);

            //TODO => Implementar fluxo de novo responsável.
        }
    }
}