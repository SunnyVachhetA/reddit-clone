using BusinessAccessLayer.Abstraction;
using DataAccessLayer.Abstraction;
using Entities.DataModels;

namespace BusinessAccessLayer.Implementation;

public class SubRedditTopicService : ISubRedditTopicService
{
    #region Properties

    private readonly ISubRedditTopicRepository _subRedditTopicRepository;

    #endregion Properties

    #region Constructor

    public SubRedditTopicService(ISubRedditTopicRepository subRedditTopicRepository)
    {
        _subRedditTopicRepository = subRedditTopicRepository;
    }

    #endregion Constructor

    #region Interface Methods

    public async Task AddAsync(Guid id, int[]? topics, CancellationToken cancellationToken)
    {
        if (topics is null || topics.Length == 0) return;

        List<SubRedditTopic> models = new();

        foreach (int topicId in topics)
        {
            models.Add(new() { SubRedditId = id, TopicId = topicId });
        }

        await _subRedditTopicRepository.AddRangeAsync(models, cancellationToken);
    }

    #endregion Interface Methods
}