namespace BusinessAccessLayer.Abstraction;
public interface ISubRedditTopicService
{
    Task AddAsync(Guid id, int[]? topics, CancellationToken cancellationToken);
}
