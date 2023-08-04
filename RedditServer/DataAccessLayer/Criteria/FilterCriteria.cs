using System.Linq.Expressions;

namespace DataAccessLayer.Criteria;
public class FilterCriteria<T> where T : class
{
    public Expression<Func<T, bool>>? Filter { get; set; } = null;

    public List<Expression<Func<T, object>>> IncludeExpressions { get; set; } = new();

    public Expression<Func<T, T>>? Select { get; set; } = null;
}
