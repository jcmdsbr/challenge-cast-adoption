using SGA.Application.Domain.Animal;
using SGA.Domain.Animal.Validations;
using SGA.Domain.Core;

namespace SGA.Domain.Animal.Commands
{
    public class RegisterNewAnimalCommand : Command<Entities.Models.Animal>, IRegisterNewAnimalCommand
    {
        public override void Execute(Entities.Models.Animal animal)
        {
            var validation = new RegisterNewAnimalValidation().Validate(animal);

            // todo => implementar registro de novo animal.
        }
    }
}