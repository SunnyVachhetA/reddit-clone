namespace Entities.DTOs.Response;
public record RedditTopicResponseDto(
        int Id,
        string Title,
        bool Selected = false
    );