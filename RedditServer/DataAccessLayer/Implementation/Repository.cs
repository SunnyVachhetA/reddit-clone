using DataAccessLayer.Abstraction;
using DataAccessLayer.Criteria;
using DataAccessLayer.Data;
using DataAccessLayer.QueryExtensions;
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

    public async Task AddRangeAsync(IEnumerable<T> models,
        CancellationToken cancellationToken = default)
        => await _dbSet.AddRangeAsync(models, cancellationToken);

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(filter, cancellationToken);

    public async Task<T?> FirstOrDefaultAsync(FilterCriteria<T> criteria,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = await GetAll(cancellationToken);

        return await query.ApplyCriteria(criteria, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(filter, cancellationToken);

    public async Task UpdateAsync(T model,
        CancellationToken cancellationToken = default)
    => await Task.Run(() => _dbSet.Update(model), cancellationToken);

    public async Task<IQueryable<T>> GetAll(CancellationToken cancellationToken = default)
        => await Task.Run(
            () => _dbSet.AsNoTracking().AsQueryable(),
            cancellationToken);

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter,
        CancellationToken cancellationToken = default)
        => filter is null ? await GetAll(cancellationToken)
            : (IEnumerable<T>)await Task.Run(() => _dbSet.Where(filter), cancellationToken);

    #endregion Interface methods
}