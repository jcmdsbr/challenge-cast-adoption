using SGA.Application.Core;

namespace SGA.Infra.Dapper.Factory
{
    public class DapperConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public DapperConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnection()
        {
            return _connectionString;
        }
    }
}
