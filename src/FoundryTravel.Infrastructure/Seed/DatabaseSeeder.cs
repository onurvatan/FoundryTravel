using FoundryTravel.Domain.Entities;
using FoundryTravel.Infrastructure.Persistence;

namespace FoundryTravel.Infrastructure.Seed;

public static class DatabaseSeeder
{
    public static void Seed(FoundryTravelDbContext db)
    {
        if (db.Cities.Any())
            return; // Already seeded

        var london = new City("London", "United Kingdom");
        var paris = new City("Paris", "France");
        var rome = new City("Rome", "Italy");

        db.Cities.AddRange(london, paris, rome);

        db.Hotels.AddRange(
            new Hotel(
                london.Id,
                "The London Grand",
                "Luxury hotel in central London with modern rooms and premium service.",
                5,
                250,
                "1 Piccadilly Road"
            ),
            new Hotel(
                london.Id,
                "Riverside Inn",
                "Cozy hotel near the Thames, perfect for weekend getaways.",
                4,
                150,
                "22 River Street"
            ),
            new Hotel(
                paris.Id,
                "Hotel Lumière",
                "Elegant Parisian hotel with Eiffel Tower views.",
                5,
                300,
                "10 Rue de Paris"
            ),
            new Hotel(
                rome.Id,
                "Roma Heritage Hotel",
                "Classic Roman architecture with modern amenities.",
                4,
                180,
                "Via Roma 12"
            )
        );

        db.SaveChanges();
    }
}