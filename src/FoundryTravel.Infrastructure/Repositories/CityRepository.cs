using FoundryTravel.Domain.Entities;
using FoundryTravel.Domain.Interfaces;
using FoundryTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoundryTravel.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly FoundryTravelDbContext _context;

    public CityRepository(FoundryTravelDbContext context)
    {
        _context = context;
    }

    public async Task<City?> GetByIdAsync(Guid id)
    {
        return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }
}