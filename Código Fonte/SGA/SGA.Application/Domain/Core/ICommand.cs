using System.Collections.Generic;

namespace SGA.Application.Domain.Core
{
    public interface ICommand<in T>
    {
        void Execute(T obj);

        bool HasErrors();

        List<string> GetErrors();
    }
}