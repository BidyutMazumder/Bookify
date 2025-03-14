using Bookify.Domain.Abstraction;
using System.Security.Cryptography.X509Certificates;

namespace Bookify.Domain.Apartments;

public sealed class Apartment: Entity
{
    public Apartment(Guid id) : base(id)
    {
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money PriceAmount { get; private set; }
    public Money CleeningFeeAmount { get; private set; }
    public DateTime? LastBookedOnUtc { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
}
