namespace FoundryTravel.Domain.Interfaces;

using FoundryTravel.Domain.Entities;

public interface IHotelRepository
{
    Task<Hotel?> GetByIdAsync(Guid id);
    Task<(IEnumerable<Hotel> Hotels, int totalCount)> SearchAsync(Guid? cityId = null, decimal? maxPrice = null, int? starRating = null, int page = 1, int pageSize = 10);
    Task AddAsync(Hotel hotel);
}