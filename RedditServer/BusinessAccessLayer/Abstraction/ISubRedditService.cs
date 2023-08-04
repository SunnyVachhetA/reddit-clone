using Entities.DTOs.Request;
using Entities.DTOs.Response;

namespace BusinessAccessLayer.Abstraction;
public interface ISubRedditService
{
    Task<string> CreateAsync(NewSubRedditRequestDto dto, CancellationToken cancellationToken = default);
    Task<SubRedditProfileResponseDto> GetAsync(string slug, CancellationToken cancellationToken);
}
