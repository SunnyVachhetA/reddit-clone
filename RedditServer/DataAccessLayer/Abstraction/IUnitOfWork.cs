using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLayer.Abstraction;
public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransactionAsync();
}
