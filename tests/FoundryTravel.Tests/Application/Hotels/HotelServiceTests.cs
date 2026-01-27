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
    public async Task SearchAsync_ReturnsPagedResult_WithCorrectMetadata()
    {
        // Arrange
        var cityId = Guid.NewGuid();

        var hotels = new List<Hotel>
        {
            new Hotel(cityId, "Hotel A", "Desc", 4, 100, "Address A"),
            new Hotel(cityId, "Hotel B", "Desc", 3, 80, "Address B")
        };

        _hotelRepositoryMock
            .Setup(r => r.SearchAsync(cityId, null, null, 1, 10))
            .ReturnsAsync((hotels, 25));

        // Act
        var result = await _hotelService.SearchAsync(cityId, null, null, 1, 10);

        // Assert
        Assert.Equal(2, result.Items.Count());
        Assert.Equal(25, result.TotalCount);
        Assert.Equal(1, result.Page);
        Assert.Equal(10, result.PageSize);
    }

    [Fact]
    public async Task SearchAsync_MapsHotelsToDtos()
    {
        // Arrange
        var cityId = Guid.NewGuid();

        var hotels = new List<Hotel>
        {
            new Hotel(cityId, "Mapped Hotel", "Nice", 5, 200, "123 Street")
        };

        _hotelRepositoryMock
            .Setup(r => r.SearchAsync(cityId, null, null, 1, 10))
            .ReturnsAsync((hotels, 1));

        // Act
        var result = await _hotelService.SearchAsync(cityId, null, null, 1, 10);

        // Assert
        var dto = result.Items.First();
        Assert.Equal("Mapped Hotel", dto.Name);
        Assert.Equal(5, dto.StarRating);
        Assert.Equal(200, dto.BasePricePerNight);
    }

    [Fact]
    public async Task SearchAsync_ReturnsEmptyList_WhenNoHotelsFound()
    {
        var cityId = Guid.NewGuid();

        _hotelRepositoryMock
            .Setup(r => r.SearchAsync(cityId, null, null, 1, 10))
            .ReturnsAsync((Enumerable.Empty<Hotel>(), 0));

        var result = await _hotelService.SearchAsync(cityId, null, null, 1, 10);

        Assert.Empty(result.Items);
        Assert.Equal(0, result.TotalCount);
    }

    [Fact]
    public async Task SearchAsync_PassesCorrectParametersToRepository()
    {
        var cityId = Guid.NewGuid();

        _hotelRepositoryMock
            .Setup(r => r.SearchAsync(cityId, 150, 4, 2, 5))
            .ReturnsAsync((Enumerable.Empty<Hotel>(), 0));

        await _hotelService.SearchAsync(cityId, 150, 4, 2, 5);

        _hotelRepositoryMock.Verify(r =>
            r.SearchAsync(cityId, 150, 4, 2, 5),
            Times.Once);
    }
}