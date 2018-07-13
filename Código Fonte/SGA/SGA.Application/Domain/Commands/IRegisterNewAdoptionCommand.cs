using SGA.Application.Domain.Core;
using SGA.Domain.Entities.Models;

namespace SGA.Application.Domain.Commands
{
    public interface IRegisterNewAdoptionCommand : ICommand<Adoption>
    {
    }
}