using System;
using System.Collections.Generic;

namespace SGA.Application.Core
{
    public interface IQuery<TEntity>
    {
        TEntity Find(Func<TEntity, Guid> expression);
        IEnumerable<TEntity> List();
    }
}