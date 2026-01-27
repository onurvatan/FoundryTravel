namespace FoundryTravel.Domain.Entities;

public class City
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Country { get; private set; }

    private City() { }

    public City(string name, string country)
    {
        Id = Guid.NewGuid();
        Name = name;
        Country = country;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("City name is required.");

        if (string.IsNullOrWhiteSpace(Country))
            throw new ArgumentException("Country is required.");
    }
}