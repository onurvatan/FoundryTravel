using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Domain.Interfaces;

namespace FoundryTravel.Application.Services
{
    public class CityService(ICityRepository cityRepository) : ICityService
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        public Task<IEnumerable<CityDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CityDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
