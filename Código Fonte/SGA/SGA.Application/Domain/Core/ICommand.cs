namespace SGA.Application.Domain.Core
{
    public interface ICommand<in T>
    {
        void Execute(T obj);
    }
}