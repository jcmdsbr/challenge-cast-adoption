using Dapper.Contrib.Extensions;
using SGA.Application.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SGA.Infra.Dapper.Core
{
    public class BaseQuery<T> : IQuery<T> where T : class, new()
    {
        protected readonly IConnectionFactory _connectionFactory;

        public BaseQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public T Find(Func<T, Guid> id)
        {
            T entity;

            using (var connection = new SqlConnection(_connectionFactory.GetConnection()))
            {
                entity = connection.Get<T>(id);
            }

            return entity;
        }

        public IEnumerable<T> List()
        {
            IEnumerable<T> entities;

            using (var connection = new SqlConnection(_connectionFactory.GetConnection()))
            {
                entities = connection.GetAll<T>();
            }

            return entities;
        }
    }
}
