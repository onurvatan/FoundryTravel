using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Domain.Interfaces;

namespace FoundryTravel.Application.Services
{
    public class HotelService(IHotelRepository  hotelRepository) : IHotelService
    {
        private readonly IHotelRepository _hotelRepository = hotelRepository;

        public async Task<PagedResult<HotelDto>> SearchAsync(
            Guid cityId,
            decimal? maxPrice,
            int? starRating,
            int page,
            int pageSize)
        {
            var (hotels, totalCount) = await _hotelRepository.SearchAsync(
                cityId,
                maxPrice,
                starRating,
                page,
                pageSize
            );

            var items = hotels.Select(h => new HotelDto(
                h.Id,
                h.Name,
                h.Description,
                h.StarRating,
                h.BasePricePerNight,
                h.Address
            ));

            return new PagedResult<HotelDto>(
                Items: items,
                TotalCount: totalCount,
                Page: page,
                PageSize: pageSize
            );
        }

        public async Task<HotelDto?> GetByIdAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return null;

            return new HotelDto(
                hotel.Id,
                hotel.Name,
                hotel.Description,
                hotel.StarRating,
                hotel.BasePricePerNight,
                hotel.Address
            );
        }

    }
}
