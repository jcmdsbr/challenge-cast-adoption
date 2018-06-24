using SGA.Domain.Adoption.Validations;
using SGA.Domain.Core;

namespace SGA.Domain.Adoption.Commands
{
    public class RegisterNewAdoptionCommand : Command<Entities.Models.Adoption>
    {
        public override void Execute(Entities.Models.Adoption adoption)
        {
            var validation = new RegisterNewAdoptionValidation().Validate(adoption);
            // todo=> implementar 
        }
    }
}