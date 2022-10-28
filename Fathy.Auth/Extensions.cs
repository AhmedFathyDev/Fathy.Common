using Fathy.Startup;
using Microsoft.AspNetCore.Identity;

namespace Fathy.Auth;

public static class Extensions
{
    public static Response ToApplicationResponse(this IdentityResult identityResult)
    {
        var errors = identityResult.Errors.Select(identityError => new Error(identityError.Code, identityError.Description ));
        return new Response(identityResult.Succeeded, errors);
    }
}