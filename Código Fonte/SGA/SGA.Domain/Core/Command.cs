using System.Collections.Generic;
using System.Linq;
using SGA.Application.Domain.Core;

namespace SGA.Domain.Core
{
    public abstract class Command<T> : ICommand<T>
    {
        private readonly List<string> _errors = new List<string>();

        public bool HasErrors()
        {
            return _errors.Any();
        }

        public List<string> GetErrors()
        {
            return _errors;
        }

        protected void AddError(string error)
        {
            _errors.Add(error);
        }

        protected void AddErros(List<string> errors)
        {
             _errors.AddRange(errors);
        }

        public abstract void Execute(T entity);
    }
}