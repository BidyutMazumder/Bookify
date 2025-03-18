using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid BookingId): IDomainEvent;