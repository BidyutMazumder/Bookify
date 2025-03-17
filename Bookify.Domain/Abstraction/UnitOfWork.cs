namespace Bookify.Domain.Abstraction;

public interface UnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
