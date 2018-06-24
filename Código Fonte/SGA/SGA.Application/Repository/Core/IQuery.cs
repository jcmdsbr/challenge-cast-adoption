using System;
using System.Collections.Generic;

namespace SGA.Application.Repository.Core
{
    public interface IQuery<TEntity>
    {
        TEntity Find(Func<TEntity, bool> expression);
        ICollection<TEntity> List();
    }
}