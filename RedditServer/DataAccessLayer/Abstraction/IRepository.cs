using DataAccessLayer.Criteria;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstraction;

public interface IRepository<T> where T : class
{
    Task AddAsync(T model, CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<T> models, CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(FilterCriteria<T> criteria, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

    Task UpdateAsync(T model, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default);

    Task<IQueryable<T>> GetAll(CancellationToken cancellationToken = default);
}