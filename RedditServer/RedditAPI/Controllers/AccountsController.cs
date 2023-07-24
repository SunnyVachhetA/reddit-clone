using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Entities.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
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
        await _accountService.Login(dto);

        return ResponseHelper.SuccessResponse(null);
    }

    #endregion Endpoint Methods
}