using FoundryTravel.Domain.Interfaces;
using FoundryTravel.Infrastructure.Persistence;
using FoundryTravel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoundryTravel.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        bool useInMemory,
        string? connectionString = null)
    {
        if (useInMemory)
        {
            services.AddDbContext<FoundryTravelDbContext>(options =>
                options.UseInMemoryDatabase("FoundryTravelDb"));
        }
        else
        {
            services.AddDbContext<FoundryTravelDbContext>(options =>
                options.UseSqlServer(connectionString!));
        }

        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<ICityRepository, CityRepository>();

        return services;
    }
}