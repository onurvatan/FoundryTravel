using FoundryTravel.Application.DTOs;
namespace FoundryTravel.Application.Interfaces;

public interface IHotelService
{
    Task<PagedResult<HotelDto>> SearchAsync(Guid cityId, decimal? maxPrice, int? starRating, int page = 1, int pageSize = 10);
    Task<HotelDto?> GetByIdAsync(Guid id);
}