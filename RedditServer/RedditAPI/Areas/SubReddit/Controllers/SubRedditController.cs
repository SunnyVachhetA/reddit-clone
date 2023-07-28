using BusinessAccessLayer.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace RedditAPI.Areas.SubReddit.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubRedditController : ControllerBase
{
    #region Properties

    private readonly ISubRedditService _subRedditService;

    #endregion Properties

    #region Constructors

    public SubRedditController(ISubRedditService subRedditService)
    {
        _subRedditService = subRedditService;
    }

    #endregion Constructors

    #region Endpoint Methods
    #endregion
}