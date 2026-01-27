using FoundryTravel.Application.DTOs;
using FoundryTravel.Application.Interfaces;
using FoundryTravel.Application.Services;
using FoundryTravel.Domain.Entities;
using FoundryTravel.Domain.Interfaces;
using Moq;

namespace FoundryTravel.Tests.Application.Hotels;

public class HotelServiceTests
{
    private readonly Mock<IHotelRepository> _hotelRepositoryMock;
    private readonly IHotelService _hotelService;

    public HotelServiceTests()
    {
        _hotelRepositoryMock = new Mock<IHotelRepository>();
        _hotelService = new HotelService(_hotelRepositoryMock.Object);
    }

    [Fact]
    public async Task SearchAsync_ReturnsMappedHotelDtos()
    {
        // Arrange
        var cityId = Guid.NewGuid();
        var hotels = new List<Hotel>
        {
            new Hotel(cityId, "Test Hotel", "Nice place", 4, 120, "123 Street")
        };

        _hotelRepositoryMock
            .Setup(r => r.SearchAsync(cityId, null, null))
            .ReturnsAsync(hotels);

        // Act
        var result = await _hotelService.SearchAsync(cityId, null, null);

        // Assert
        Assert.Single(result);
        var dto = result.First();
        Assert.Equal("Test Hotel", dto.Name);
        Assert.Equal(4, dto.StarRating);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenHotelNotFound()
    {
        _hotelRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Hotel?)null);

        var result = await _hotelService.GetByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }
}