using Dapper.Contrib.Extensions;
using SGA.Application.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SGA.Infra.Dapper.Core
{
    public class BaseQuery<T> : IQuery<T> where T : class
    {
        protected readonly DbConnection _connection;

        public BaseQuery(DbConnection connection)
        {
            _connection = connection;
        }

        public T Find(Func<T, Guid> id)
        {
            T entity;

            using (var connection = _connection)
            {
                entity = connection.Get<T>(id);
            }

            return entity;
        }

        public IEnumerable<T> List()
        {
            IEnumerable<T> entities;

            using (var connection = _connection)
            {
                entities = connection.GetAll<T>();
            }

            return entities;
        }
    }
}
