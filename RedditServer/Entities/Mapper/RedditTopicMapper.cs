using Entities.DataModels;
using Entities.DTOs.Response;

namespace Entities.Mapper;

public static class RedditTopicMapper
{
    public static RedditTopicResponseDto ToRedditTopicResponseDto(this RedditTopic model)
        => new(model.Id, model.Title);
}