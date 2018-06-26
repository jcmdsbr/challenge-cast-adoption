using SGA.Application.Domain.Core;

namespace SGA.Application.Domain.Pet
{
    public interface IRegisterNewPetCommand : ICommand<SGA.Domain.Entities.Models.Pet>
    {
    }
}