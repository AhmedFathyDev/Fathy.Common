using Microsoft.AspNetCore.Identity;

namespace Fathy.Auth.JWTGenerator.Repositories;

public interface IJwtGeneratorRepository
{
    Task<string> GenerateJwtSecurityToken(IdentityUser user);
}