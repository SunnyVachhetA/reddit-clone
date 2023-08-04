using Entities.DataModels;
using Entities.DTOs.Request;
using Entities.DTOs.Response;

namespace Entities.Mapper;
public static class SubRedditMapper
{
    public static SubReddit ToSubReddit(this NewSubRedditRequestDto dto)
        => new()
        {
            Title = dto.Title,
            Slug = dto.Slug,
            Description = dto.Description,
            Type = dto.Type
        };

    public static SubRedditProfileResponseDto ToSubRedditProfileResponseDto(this SubReddit model)
    {
        SubRedditProfileResponseDto dto = new()
        {
            Id = model.Id,
            CreatedOn = model.CreatedOn,
            Slug = model.Slug,
            Description = model.Description,
            Title = model.Title,
            Type = model.Type,
            Status = model.Status,
            MemberCount = model.MemberCount,
            IconUrl = model.Icon,
            BannerUrl = model.Banner,
            CreatedBy = model.CreatedBy.ToUserProfilePeekResponseDto(),
            Moderators = model.Moderators
                              .Select(mod => new UserProfilePeekResponseDto(mod.UserId, mod.User.Username)),
            TopicDictionary = model.Topics
                                   .Select(topic => new SubRedditTopicDictionaryDto(topic.TopicId, topic.Topic.Title))
        };

        return dto;
    }
}
