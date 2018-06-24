using System;
using System.Collections.Generic;
using System.Text;
using SGA.Domain.Entities.Core;

namespace SGA.Application.Repository
{
    public interface IQuery<TEntity> where TEntity : Entity
    {
        TEntity Find(Func<TEntity, bool> expression);
        TEntity FindById(Guid id);
        IEnumerable<TEntity> List();
    }
}
