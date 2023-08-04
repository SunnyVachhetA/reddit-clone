using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLayer.Implementation;

public class UnitOfWork : IUnitOfWork
{
    #region Properties

    private readonly AppDbContext _dbContext;

    #endregion Properties

    #region Constructor

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion Constructor

    #region Interface methods

    public async Task SaveAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_dbContext.Database.CurrentTransaction != null)
        {
            throw new InvalidOperationException("A transaction is already in progress.");
        }

        return await _dbContext.Database.BeginTransactionAsync();
    }
    #endregion Interface methods
}