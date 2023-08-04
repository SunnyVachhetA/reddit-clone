using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BusinessAccessLayer.AppUser;

public class ApplicationUser : IApplicationUser
{
    #region Properties

    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion Properties

    #region Constructors

    public ApplicationUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion Constructors

    #region Interface Methods

    public Guid? GetUserId()
    {
        Claim? claim = GetClaim(ClaimTypes.NameIdentifier);

        if (claim is null) return null;

        return Guid.TryParse(claim.Value, out Guid userId) ? userId : null;
    }

    #endregion Interface Methods

    #region Helper Methods

    private Claim? GetClaim(string claimName)
    {
        ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;

        if (user is null || !user.Identity!.IsAuthenticated) return null;

        Claim? claim = user.FindFirst(claimName);

        return claim;
    }

    #endregion Helper Methods
}