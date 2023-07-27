using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Common.Utils;
using Entities.DTOs.Request;
using Entities.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Helpers;
using WebAPI.Filters;

namespace RedditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    #region Properties

    private readonly IAccountService _accountService;

    #endregion Properties

    #region Constructor

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    #endregion Constructor

    #region Endpoint Methods

    [HttpPost("register")]
    [ValidateModel]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto,
        CancellationToken cancellationToken)
    {
        await _accountService.Register(dto, cancellationToken);

        return ResponseHelper.CreateResourceResponse(null, MessageConstants.AccountCreated);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto,
        CancellationToken cancellationToken)
    {
        UserAuthTokenDto authDto = await _accountService.Login(dto, cancellationToken);

        CookieOptions options = new()
        {
            HttpOnly = true,
            Expires = DateUtil.AddDays(SystemConstants.RefreshTokenExpiryInDays)
        };

        CookieHelper.SetCookie(Response, SystemConstants.RefreshTokenKey, authDto.RefreshToken.Token, options);

        return ResponseHelper.SuccessResponse(authDto, MessageConstants.LoginSuccess);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return ResponseHelper.SuccessResponse(null, "This is auth resource accessed by client.");
    }

    #endregion Endpoint Methods
}