using SGA.Application.Core;

namespace SGA.Infra.Dapper.Core
{
    public class BaseQuery<T> : IQuery<T> where T : class
    {
        protected readonly IConnectionFactory ConnectionFactory;

        public BaseQuery(IConnectionFactory connection)
        {
            ConnectionFactory = connection;
        }
    }
}