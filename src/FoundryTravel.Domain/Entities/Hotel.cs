namespace FoundryTravel.Domain.Entities;

public class Hotel
{
    public Guid Id { get; private set; }
    public Guid CityId { get; private set; }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public int StarRating { get; private set; }
    public decimal BasePricePerNight { get; private set; }
    public string Address { get; private set; }

    // Navigation-like collections (domain-side only)
    private readonly List<RoomType> _roomTypes = new();
    public IReadOnlyCollection<RoomType> RoomTypes => _roomTypes.AsReadOnly();

    private readonly List<Review> _reviews = new();
    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

    private readonly List<Amenity> _amenities = new();
    public IReadOnlyCollection<Amenity> Amenities => _amenities.AsReadOnly();

    private Hotel() { } // EF Core needs this later

    public Hotel(Guid cityId, string name, string description, int starRating, decimal basePricePerNight, string address)
    {
        Id = Guid.NewGuid();
        CityId = cityId;
        Name = name;
        Description = description;
        StarRating = starRating;
        BasePricePerNight = basePricePerNight;
        Address = address;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Hotel name is required.");

        if (StarRating < 1 || StarRating > 5)
            throw new ArgumentException("Star rating must be between 1 and 5.");

        if (BasePricePerNight < 0)
            throw new ArgumentException("Price per night cannot be negative.");
    }

    // Domain behavior examples
    public void AddRoomType(RoomType roomType) => _roomTypes.Add(roomType);
    public void AddReview(Review review) => _reviews.Add(review);
    public void AddAmenity(Amenity amenity) => _amenities.Add(amenity);
}