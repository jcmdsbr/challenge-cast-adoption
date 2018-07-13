using SGA.Application.Core;
using SGA.Application.Domain.Commands;
using SGA.Application.Repository;
using SGA.Domain.Commands.Core;
using SGA.Domain.Entities.Models;
using SGA.Domain.Validations;
using System.Linq;

namespace SGA.Domain.Commands
{
    public class RegisterNewResponsibleCommand : Command<Responsible>, IRegisterNewResponsibleCommand
    {
        private readonly IResponsibleRepository _responsibleRepository;

        public RegisterNewResponsibleCommand(IResponsibleRepository responsibleRepository, IUnitOfWork uow)
            : base(uow)
        {
            _responsibleRepository = responsibleRepository;
        }

        public override void Execute(Responsible responsible)
        {
            var validation = new RegisterNewResponsibleValidation().Validate(responsible);

            if (!validation.IsValid)
            {
                AddErros(validation.Errors.Select(x => x.ErrorMessage).ToList());
                return;
            }

            responsible.CreateNewId();

            _responsibleRepository.Add(responsible);

            Commit();
        }
    }
}