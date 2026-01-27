using FoundryTravel.Domain.Entities;
using FoundryTravel.Domain.Interfaces;
using FoundryTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoundryTravel.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly FoundryTravelDbContext _context;

    public HotelRepository(FoundryTravelDbContext context)
    {
        _context = context;
    }

    public async Task<Hotel?> GetByIdAsync(Guid id)
    {
        return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task AddAsync(Hotel hotel)
    {
        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task<(IEnumerable<Hotel>, int)> SearchAsync(
        Guid cityId, decimal? maxPrice, int? starRating, int page, int pageSize)
    {
        var query = _context.Hotels.Where(h => h.CityId == cityId);

        if (maxPrice.HasValue)
            query = query.Where(h => h.BasePricePerNight <= maxPrice.Value);

        if (starRating.HasValue)
            query = query.Where(h => h.StarRating == starRating.Value);

        var total = await query.CountAsync();

        var hotels = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (hotels, total);
    }
}