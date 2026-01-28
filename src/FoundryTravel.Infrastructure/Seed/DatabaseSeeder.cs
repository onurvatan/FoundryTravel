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
        var barcelona = new City("Barcelona", "Spain");
        var amsterdam = new City("Amsterdam", "Netherlands");
        var vienna = new City("Vienna", "Austria");
        var prague = new City("Prague", "Czech Republic");

        db.Cities.AddRange(london, paris, rome, barcelona, amsterdam, vienna, prague);

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
                london.Id,
                "Westminster Suites",
                "Boutique hotel steps away from Big Ben and Westminster Abbey.",
                4,
                200,
                "45 Parliament Square"
            ),
            new Hotel(
                london.Id,
                "Kensington Palace Hotel",
                "Elegant Victorian hotel near Hyde Park and Kensington Gardens.",
                5,
                350,
                "18 Kensington High Street"
            ),
            new Hotel(
                london.Id,
                "Shoreditch Urban Loft",
                "Trendy boutique hotel in the heart of East London's creative district.",
                3,
                130,
                "88 Brick Lane"
            ),
            new Hotel(
                london.Id,
                "Tower Bridge Residences",
                "Modern apartments with iconic views of Tower Bridge and the Tower of London.",
                4,
                220,
                "3 Tower Hill"
            ),
            new Hotel(
                london.Id,
                "Covent Garden Hotel",
                "Stylish hotel in the West End, perfect for theatre lovers.",
                4,
                240,
                "10 Monmouth Street"
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
                paris.Id,
                "Le Petit Château",
                "Charming boutique hotel in the heart of Le Marais district.",
                3,
                120,
                "5 Rue des Rosiers"
            ),
            new Hotel(
                rome.Id,
                "Roma Heritage Hotel",
                "Classic Roman architecture with modern amenities.",
                4,
                180,
                "Via Roma 12"
            ),
            new Hotel(
                rome.Id,
                "Colosseum View Inn",
                "Budget-friendly hotel with stunning views of the Colosseum.",
                3,
                95,
                "Via del Colosseo 8"
            ),
            new Hotel(
                barcelona.Id,
                "Hotel Gaudí Palace",
                "Modernist-inspired luxury hotel near La Sagrada Familia.",
                5,
                280,
                "Carrer de Mallorca 401"
            ),
            new Hotel(
                barcelona.Id,
                "Barceloneta Beach Hotel",
                "Beachfront hotel with Mediterranean Sea views and rooftop pool.",
                4,
                190,
                "Passeig Marítim 25"
            ),
            new Hotel(
                amsterdam.Id,
                "Canal House Hotel",
                "Historic canal-side hotel in a renovated 17th-century building.",
                4,
                175,
                "Herengracht 124"
            ),
            new Hotel(
                amsterdam.Id,
                "The Tulip Garden Inn",
                "Modern hotel near Vondelpark with bicycle rentals included.",
                3,
                110,
                "Overtoom 55"
            ),
            new Hotel(
                vienna.Id,
                "Imperial Vienna Hotel",
                "Opulent hotel near the Vienna State Opera with classical décor.",
                5,
                320,
                "Kärntner Ring 16"
            ),
            new Hotel(
                vienna.Id,
                "Schönbrunn Gardens Hotel",
                "Family-friendly hotel adjacent to the famous Schönbrunn Palace.",
                4,
                160,
                "Schönbrunner Schloßstraße 47"
            ),
            new Hotel(
                prague.Id,
                "Old Town Square Hotel",
                "Historic hotel overlooking Prague's iconic astronomical clock.",
                4,
                140,
                "Staroměstské náměstí 20"
            ),
            new Hotel(
                prague.Id,
                "Charles Bridge Residence",
                "Cozy hotel with views of the Vltava River and Charles Bridge.",
                3,
                100,
                "Křížovnická 12"
            )
        );

        db.SaveChanges();
    }
}