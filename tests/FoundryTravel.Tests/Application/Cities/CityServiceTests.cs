using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Application.Services;
using FoundryTravel.Domain.Entities;
using FoundryTravel.Domain.Interfaces;
using Moq;

namespace FoundryTravel.Tests.Application.Cities;

public class CityServiceTests
{
    private readonly Mock<ICityRepository> _cityRepositoryMock;
    private readonly ICityService _cityService;

    public CityServiceTests()
    {
        _cityRepositoryMock = new Mock<ICityRepository>();
        _cityService = new CityService(_cityRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsMappedCityDtos()
    {
        var cities = new List<City>
        {
            new City("London", "UK"),
            new City("Paris", "France")
        };

        _cityRepositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(cities);

        var result = await _cityService.GetAllAsync();

        Assert.Equal(2, result.Count());
        Assert.Contains(result, c => c.Name == "London");
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenCityNotFound()
    {
        _cityRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((City?)null);

        var result = await _cityService.GetByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }
}