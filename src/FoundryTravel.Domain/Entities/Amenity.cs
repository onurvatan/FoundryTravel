namespace FoundryTravel.Domain.Entities;

public class Amenity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Amenity() { }

    public Amenity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}