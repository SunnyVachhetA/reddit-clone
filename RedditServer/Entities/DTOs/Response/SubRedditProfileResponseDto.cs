using Common.Enums;

namespace Entities.DTOs.Response;

public class SubRedditProfileResponseDto
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Slug { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long MemberCount { get; set; }

    public UserProfilePeekResponseDto CreatedBy { get; set; } = null!;

    public string IconUrl { get; set; } = string.Empty;

    public string BannerUrl { get; set; } = string.Empty;

    public IEnumerable<SubRedditTopicDictionaryDto> TopicDictionary { get; set; }
        = Enumerable.Empty<SubRedditTopicDictionaryDto>();

    public IEnumerable<UserProfilePeekResponseDto> Moderators { get; set; }
        = Enumerable.Empty<UserProfilePeekResponseDto>();

    public SubRedditType Type { get; set; }

    public SubRedditStatusType Status { get; set; }
}