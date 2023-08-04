namespace BusinessAccessLayer.Abstraction;
public interface ISubRedditModeratorService
{
    Task AddAsync(Guid subRedditId, Guid userId);
}
