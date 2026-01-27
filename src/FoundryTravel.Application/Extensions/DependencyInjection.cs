using FoundryTravel.Application.Interfaces;
using FoundryTravel.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FoundryTravel.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IAiService, AiService>();

        return services;
    }
}