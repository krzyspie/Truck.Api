using Dapper;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Repositories
{
    internal class TruckRepository : ITruckRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public TruckRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task Create()
        {
            string code = "abc";
            string name = "myNameee";
            int status = 3;
            string description = "descccc";
            using var connection = _sqlConnectionFactory.Create();
            var results = await connection.ExecuteAsync(
                "[dbo].[spTruck_Insert]",
                new { code, name, status, description },
                commandType: CommandType.StoredProcedure);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Truck> GetByIdAsync(int id)
        {
            using var connection = _sqlConnectionFactory.Create();
            var results = await connection.QueryAsync<Truck>(
                $"[ReadByEmail]",
                new { id },
                commandType: CommandType.StoredProcedure);

            return results.SingleOrDefault();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
