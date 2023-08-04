using Common.Enums;
using Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Request;

public class NewSubRedditRequestDto : BaseValidationModel<NewSubRedditRequestDto>
{
    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public IFormFile Icon { get; set; } = null!;

    public IFormFile Banner { get; set; } = null!;

    public string Description { get; set; } = string.Empty;

    public SubRedditType Type { get; set; }

    public int[]? Topics { get; set; }
}