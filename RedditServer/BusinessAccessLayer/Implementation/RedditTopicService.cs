using BusinessAccessLayer.Abstraction;
using DataAccessLayer.Abstraction;
using Entities.DataModels;
using Entities.DTOs.Response;
using Entities.Mapper;

namespace BusinessAccessLayer.Implementation;

public class RedditTopicService : IRedditTopicService
{
    #region Properties

    private readonly IRedditTopicRepository _redditTopicRepository;

    #endregion Properties

    #region Constructor

    public RedditTopicService(IRedditTopicRepository redditTopicRepository)
    {
        _redditTopicRepository = redditTopicRepository;
    }

    #endregion Constructor

    #region Interface methods

    public async Task<IEnumerable<RedditTopicResponseDto>> GetAll(CancellationToken cancellationToken = default)
    {
        IEnumerable<RedditTopic> models = await _redditTopicRepository.GetAll(cancellationToken: cancellationToken);

        return models.Select(ConvertToRedditTopicResponseDto);
    }

    #endregion Interface methods

    #region Helper Methods

    private static RedditTopicResponseDto ConvertToRedditTopicResponseDto(RedditTopic model)
        => model.ToRedditTopicResponseDto();

    #endregion
}