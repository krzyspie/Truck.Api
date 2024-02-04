using Dapper;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Services;
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

        public async Task<int> CreateAsync(string code, string name, string status, string? description = null)
        {
            using var connection = _sqlConnectionFactory.Create();
            var truckId = await connection.QuerySingleAsync<int>(
                "[dbo].[spTruck_Insert]",
                new { code, name, status, description },
                commandType: CommandType.StoredProcedure);

            return truckId;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _sqlConnectionFactory.Create();
            await connection.ExecuteAsync(
                "[dbo].[spTruck_Delete]",
                new { id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Truck>> Get(string filterBy, string filterValue, string sortBy, string sortDirection)
        {
            using var connection = _sqlConnectionFactory.Create();

            var result = await connection.QueryAsync<Truck>(
                "[dbo].[spTruck_GetFilteredAndSorted]",
                new { filterBy, filterValue, sortBy, sortDirection },
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<Truck> GetByIdAsync(int id)
        {
            using var connection = _sqlConnectionFactory.Create();
            
            var result = await connection.QuerySingleOrDefaultAsync<Truck>(
                "[dbo].[spTruck_GetById]",
                new { id },
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task UpdateAsync(int id, string code, string name, string status, string? description = null)
        {
            using var connection = _sqlConnectionFactory.Create();
            await connection.ExecuteAsync(
                "[dbo].[spTruck_Update]",
                new { id, code, name, status, description },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateStatusAync(int id, string status)
        {
            using var connection = _sqlConnectionFactory.Create();
            await connection.ExecuteAsync(
                "[dbo].[spTruck_UpdateStatus]",
                new { id, status },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> IsCodeUsedAlready(string code)
        {
            using var connection = _sqlConnectionFactory.Create();

            var result = await connection.QuerySingleAsync<bool>(
                "[dbo].[spTruck_CheckTruckWithCodeExists]",
                new { code },
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
