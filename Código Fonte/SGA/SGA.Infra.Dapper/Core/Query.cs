using SGA.Application.Core;

namespace SGA.Infra.Dapper.Core
{
    public class Query<T> : IQuery<T> where T : class
    {
        protected readonly IConnectionFactory ConnectionFactory;

        public Query(IConnectionFactory connection)
        {
            ConnectionFactory = connection;
        }
    }
}