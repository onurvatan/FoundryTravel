using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Domain.Interfaces;

namespace FoundryTravel.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IEnumerable<CityDto>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();

        return cities.Select(c => new CityDto(
            c.Id,
            c.Name,
            c.Country
        ));
    }

    public async Task<CityDto?> GetByIdAsync(Guid id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city == null)
            return null;

        return new CityDto(
            city.Id,
            city.Name,
            city.Country
        );
    }
}