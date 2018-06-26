using SGA.Application.Domain.Core;

namespace SGA.Application.Domain.Adoption
{
    public interface IRegisterNewAdoptionCommand : ICommand<SGA.Domain.Entities.Models.Adoption>
    {
    }
}