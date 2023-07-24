using Entities.DataModels;
using Entities.DTOs.Request;

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
}
