using Bookify.Application.Abstractions.Clock;

namespace Bookify.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    DateTime IDateTimeProvider.UtcNow => DateTime.UtcNow;
}
