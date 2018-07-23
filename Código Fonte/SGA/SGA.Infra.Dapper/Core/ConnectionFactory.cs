using SGA.Application.Core;
using System.Data.Common;
using System.Data.SqlClient;

namespace SGA.Infra.Dapper.Core
{
    public sealed class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            if (_connection != null) return _connection;

            _connection = new SqlConnection(_connectionString);

            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}