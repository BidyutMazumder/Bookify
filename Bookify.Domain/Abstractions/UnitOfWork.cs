namespace Bookify.Domain.Abstractions;

public interface UnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
