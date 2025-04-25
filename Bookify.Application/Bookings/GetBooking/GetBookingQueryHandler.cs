
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;

namespace Bookify.Application.Bookings.GetBooking;

public sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
{
    public Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
