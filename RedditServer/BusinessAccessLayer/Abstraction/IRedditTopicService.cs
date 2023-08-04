using Entities.DTOs.Response;

namespace BusinessAccessLayer.Abstraction;
public interface IRedditTopicService
{
    Task<IEnumerable<RedditTopicResponseDto>> GetAll(CancellationToken cancellationToken = default);
}
