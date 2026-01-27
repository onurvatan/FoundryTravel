namespace FoundryTravel.Domain.Interfaces;

using FoundryTravel.Domain.Entities;

public interface IHotelRepository
{
    Task<Hotel?> GetByIdAsync(Guid id);
    Task<IEnumerable<Hotel>> SearchAsync(Guid cityId, decimal? maxPrice = null, int? starRating = null);
    Task AddAsync(Hotel hotel);
}