using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Domain.Interfaces;

namespace FoundryTravel.Application.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<IEnumerable<HotelDto>> SearchAsync(Guid cityId, decimal? maxPrice, int? starRating)
    {
        var hotels = await _hotelRepository.SearchAsync(cityId, maxPrice, starRating);

        return hotels.Select(h => new HotelDto(
            h.Id,
            h.Name,
            h.Description,
            h.StarRating,
            h.BasePricePerNight,
            h.Address
        ));
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