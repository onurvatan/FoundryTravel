namespace FoundryTravel.Application.DTOs;

public record HotelDto(
    Guid Id,
    string Name,
    string Description,
    int StarRating,
    decimal BasePricePerNight,
    string Address
);