namespace FoundryTravel.Domain.Entities;

public class RoomType
{
    public Guid Id { get; private set; }
    public Guid HotelId { get; private set; }

    public string Name { get; private set; }
    public int MaxGuests { get; private set; }
    public decimal PricePerNight { get; private set; }

    private RoomType() { }

    public RoomType(Guid hotelId, string name, int maxGuests, decimal pricePerNight)
    {
        Id = Guid.NewGuid();
        HotelId = hotelId;
        Name = name;
        MaxGuests = maxGuests;
        PricePerNight = pricePerNight;
    }
}