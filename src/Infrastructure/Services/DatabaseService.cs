using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class DatabaseService
    {
        private const string getDataBaseQuery = "SELECT 1 FROM sys.databases WHERE name = @name";
        private const string dbName = "TrucksDb";

        private readonly SqlConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;

        public DatabaseService(SqlConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }

        public void EnsureDatabaseExists()
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using var connection = _connectionFactory.Create(_configuration.GetConnectionString("MasterDb"));
            
            var records = connection.Query(getDataBaseQuery, parameters);
            if (!records.Any())
                connection.Execute($"CREATE DATABASE {dbName}");
        }
    }
}
