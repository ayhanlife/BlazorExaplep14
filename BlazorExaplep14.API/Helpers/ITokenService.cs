using Microsoft.AspNetCore.Identity;

namespace BlazorExaplep14.API.Helpers
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);

    }
}
