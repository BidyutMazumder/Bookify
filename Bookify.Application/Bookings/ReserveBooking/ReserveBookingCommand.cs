using Bookify.Application.Abstractions.Messaging;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand
    (
        Guid AppartmentId,
        Guid UserId,
        DateTime StartDate,
        DateTime EndDate
    ): ICommand<Guid>;
