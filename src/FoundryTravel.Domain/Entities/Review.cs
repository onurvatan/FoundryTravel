namespace FoundryTravel.Domain.Entities;

public class Review
{
    public Guid Id { get; private set; }
    public Guid HotelId { get; private set; }

    public int Rating { get; private set; }
    public string Title { get; private set; }
    public string Comment { get; private set; }

    private Review() { }

    public Review(Guid hotelId, int rating, string title, string comment)
    {
        Id = Guid.NewGuid();
        HotelId = hotelId;
        Rating = rating;
        Title = title;
        Comment = comment;
    }
}