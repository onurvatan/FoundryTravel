using FoundryTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoundryTravel.Infrastructure.Persistence;

public class FoundryTravelDbContext(DbContextOptions<FoundryTravelDbContext> options) : DbContext(options)
{
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<City> Cities => Set<City>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoundryTravelDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}