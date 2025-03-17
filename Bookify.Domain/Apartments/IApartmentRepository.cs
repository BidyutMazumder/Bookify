using Bookify.Domain.Users;

namespace Bookify.Domain.Apartments;

public interface IApartmentRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
