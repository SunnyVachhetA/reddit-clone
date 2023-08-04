using DataAccessLayer.Criteria;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.QueryExtensions;

public static class FilterCriteriaExtension
{
    public static async Task<T?> ApplyCriteria<T>(this IQueryable<T> query,
        FilterCriteria<T> criteria,
        CancellationToken cancellationToken = default) where T : class
    {
        query = FilterQuery(query, criteria);

        query = IncludeQuery(query, criteria);

        query = SelectQuery(query, criteria);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    private static IQueryable<T> SelectQuery<T>(IQueryable<T> query, FilterCriteria<T> criteria)
        where T : class
        => (criteria.Select is null) ? query : query.Select(criteria.Select);

    private static IQueryable<T> IncludeQuery<T>(IQueryable<T> query,
        FilterCriteria<T> criteria) where T : class
    {
        if (criteria.Select is null && criteria.IncludeExpressions.Any())
        {
            query = criteria.IncludeExpressions
                            .Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }

    private static IQueryable<T> FilterQuery<T>(IQueryable<T> query,
        FilterCriteria<T> criteria) where T : class
    {
        if (criteria.Filter is not null)
            query = query.Where(criteria.Filter);

        return query;
    }
}