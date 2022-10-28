using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Fathy.Auth.JWTGenerator.Utilities;

public static class JwtParameters
{
    public const string ValidIssuer = "https://github.com/AhmedFathyDev/";
    public const string ValidAudience = "User";

    public static readonly SymmetricSecurityKey IssuerSigningKey = new(key: Encoding.UTF8.GetBytes("xm7zdYq8KIlFftHJ6NCLYOarogKX41qv"));
}