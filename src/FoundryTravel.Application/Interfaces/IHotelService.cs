using FoundryTravel.Application.DTOs;
namespace FoundryTravel.Application.Interfaces;

public interface IHotelService
{
    Task<IEnumerable<HotelDto>> SearchAsync(Guid cityId, decimal? maxPrice, int? starRating);
    Task<HotelDto?> GetByIdAsync(Guid id);
}