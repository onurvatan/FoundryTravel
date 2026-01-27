namespace FoundryTravel.Domain.Interfaces;

using FoundryTravel.Domain.Entities;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(Guid id);
    Task<IEnumerable<City>> GetAllAsync();
}