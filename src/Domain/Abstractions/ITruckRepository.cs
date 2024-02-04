using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ITruckRepository
    {
        Task<int> CreateAsync(string code, string name, string status, string? description = null);
        Task UpdateAsync(int id, string code, string name, string status, string? description = null);
        Task DeleteAsync(int id);
        Task<Truck> GetByIdAsync(int id);
        Task UpdateStatusAync(int id, string status);
        Task<IEnumerable<Truck>> Get(string filterBy, string filterValue, string sortBy, string sortDirection);
        Task<bool> IsCodeUsedAlready(string code);
    }
}
