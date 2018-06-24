using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SGA.Domain.Entities.Core;

namespace SGA.Application.Repository
{
    public interface IRepository<TEntity> 
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
