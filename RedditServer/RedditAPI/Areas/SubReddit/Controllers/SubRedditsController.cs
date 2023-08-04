using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Entities.DTOs.Request;
using Entities.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Helpers;
using WebAPI.Filters;

namespace RedditAPI.Areas.SubReddit.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubRedditsController : ControllerBase
{
    #region Properties

    private readonly ISubRedditService _subRedditService;
    private readonly IRedditTopicService _redditTopicService;

    #endregion Properties

    #region Constructors

    public SubRedditsController(ISubRedditService subRedditService,
        IRedditTopicService redditTopicService)
    {
        _subRedditService = subRedditService;
        _redditTopicService = redditTopicService;
    }

    #endregion Constructors

    #region Endpoint Methods

    [HttpPost]
    [ServiceFilter(typeof(ValidateModelAttribute))]
    [Authorize]
    public async Task<IActionResult> Create([FromForm] NewSubRedditRequestDto dto,
        CancellationToken cancellationToken)
    {
        string subRedditSlug = await _subRedditService.CreateAsync(dto, cancellationToken);

        return ResponseHelper.SuccessResponse(subRedditSlug, MessageConstants.SubRedditCreated);
    }

    [HttpGet("topics")]
    public async Task<IActionResult> Topics(CancellationToken cancellationToken)
    {
        IEnumerable<RedditTopicResponseDto> dtos = await _redditTopicService.GetAll(cancellationToken);

        return ResponseHelper.SuccessResponse(dtos);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> Get(string slug, CancellationToken cancellationToken)
    {
        SubRedditProfileResponseDto dto = await _subRedditService.GetAsync(slug, cancellationToken);

        return ResponseHelper.SuccessResponse(dto);
    }

    #endregion Endpoint Methods
}