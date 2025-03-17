using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Apartments;
public sealed class Apartment: Entity
{
    public Apartment(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money priceAmount,
        Money cleeningFeeAmount,
        List<Amenity> amenities
        ) : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        PriceAmount = priceAmount;
        CleeningFeeAmount = cleeningFeeAmount;
        Amenities = amenities;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money PriceAmount { get; private set; }
    public Money CleeningFeeAmount { get; private set; }
    public DateTime? LastBookedOnUtc { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
}
