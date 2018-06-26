using SGA.Application.Domain.Core;

namespace SGA.Application.Domain.Pet
{
    public interface IRegisterNewAnimalCommand : ICommand<SGA.Domain.Entities.Models.Pet>
    {
    }
}