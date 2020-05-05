using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InstantPOS.Infrastructure
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }

    public class SqlConnectionFactory:IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        public SqlConnectionFactory(string connectionString = "Server=.;Database=InstantPOS;Uid=sa;Pwd=Admin@123$;MultipleActiveResultSets=true;") => _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
