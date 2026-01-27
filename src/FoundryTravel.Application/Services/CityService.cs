using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;

namespace FoundryTravel.Application.Services
{
    public class CityService : ICityService
    {
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
