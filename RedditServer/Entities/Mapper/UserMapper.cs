using Entities.DataModels;
using Entities.DTOs.Request;
using Entities.DTOs.Response;

namespace Entities.Mapper;
public static class UserMapper
{
    public static User ToUser(this RegisterRequestDto dto)
        => new()
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
        };

    public static UserProfilePeekResponseDto ToUserProfilePeekResponseDto(this User model)
        => new(model.Id, model.Username);

    public static User ToUserProfilePeek(this User model)
        => new()
        {
            Id = model.Id,
            Username = model.Username
        };
}
