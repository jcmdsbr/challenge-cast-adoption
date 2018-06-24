using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SGA.Domain.Core.Commands
{
   public abstract class Command<T>
    {

        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();

        public abstract void Execute(T entity);
      
    }
}
