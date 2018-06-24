using SGA.Application.Domain.Core;

namespace SGA.Domain.Core
{
    public abstract class Command<T> : ICommand<T>
    {
        public abstract void Execute(T entity);
    }
}