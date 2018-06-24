using SGA.Application.Domain.Core;

namespace SGA.Application.Domain.Animal
{
    public interface IRegisterNewAnimalCommand : ICommand<SGA.Domain.Entities.Models.Animal>
    {
    }
}