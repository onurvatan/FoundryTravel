using FoundryTravel.Application.DTOs;

namespace FoundryTravel.Application.Interfaces;

public interface ICityService
{
    Task<IEnumerable<CityDto>> GetAllAsync();
    Task<CityDto?> GetByIdAsync(Guid id);
}