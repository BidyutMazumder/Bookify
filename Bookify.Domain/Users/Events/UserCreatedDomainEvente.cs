using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Users.Events;

public sealed record UserCreatedDomainEvente(Guid UserId) : IDomainEvent;
