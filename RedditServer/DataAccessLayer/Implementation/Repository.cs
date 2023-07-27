using DataAccessLayer.Abstraction;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Implementation;

public class Repository<T> : IRepository<T> where T : class
{
    #region Properties

    protected readonly AppDbContext _dbContext;

    private readonly DbSet<T> _dbSet;

    #endregion Properties

    #region Constructor

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    #endregion Constructor

    #region Interface methods

    public async Task AddAsync(T model,
        CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(model, cancellationToken);

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(filter, cancellationToken);

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(filter, cancellationToken);

    public async Task UpdateAsync(T model,
        CancellationToken cancellationToken = default)
    => await Task.Run(() => _dbSet.Update(model), cancellationToken);

    #endregion Interface methods
}