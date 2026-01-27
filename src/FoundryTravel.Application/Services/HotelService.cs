using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Domain.Interfaces;

namespace FoundryTravel.Application.Services
{
    public class HotelService(IHotelRepository  hotelRepository) : IHotelService
    {
        private readonly IHotelRepository _hotelRepository = hotelRepository;

        public Task<HotelDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelDto>> SearchAsync(Guid cityId, decimal? maxPrice, int? starRating)
        {
            throw new NotImplementedException();
        }
    }
}
