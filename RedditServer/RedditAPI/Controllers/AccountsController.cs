using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Common.Exceptions;
using Entities.DTOs.Request;
using Entities.DTOs.Response;
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

        if (authDto.RefreshToken is not null)
            CookieHelper.SetRefreshTokenInCookie(Response, authDto.RefreshToken);

        return ResponseHelper.SuccessResponse(authDto, MessageConstants.LoginSuccess);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
    {
        string? refreshToken = Request.Cookies[SystemConstants.RefreshTokenKey];

        if (refreshToken is null)
            throw new ModelValidationException(MessageConstants.InvalidRefreshToken);

        UserAuthTokenDto authDto = await _accountService.RefreshToken(refreshToken, cancellationToken);

        if (authDto.RefreshToken is not null)
            CookieHelper.SetRefreshTokenInCookie(Response, authDto.RefreshToken);

        return ResponseHelper.SuccessResponse(authDto, MessageConstants.AccessTokenRefreshSuccess);
    }
    #endregion Endpoint Methods
}