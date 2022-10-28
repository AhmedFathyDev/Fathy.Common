using System.Net.Mail;
using Fathy.Auth.Admin.Repositories;
using Fathy.Auth.CurrentUser.Repositories;
using Fathy.Auth.JWTGenerator.Repositories;
using Fathy.Auth.JWTGenerator.Utilities;
using Fathy.Auth.User.Repositories;
using Fathy.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Fathy.Auth;

public static class DependencyInjection
{
    public static void AddAuthService(this IServiceCollection services, OpenApiInfo openApiInfo)
    {
        services.AddAuthentication(configureOptions =>
        {
            configureOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(configureOptions =>
        {
            configureOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = JwtParameters.ValidIssuer,
                ValidateAudience = true,
                ValidAudience = JwtParameters.ValidAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = JwtParameters.IssuerSigningKey
            };
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IJwtGeneratorRepository, JwtGeneratorRepository>();
        services.AddSingleton<ICurrentUserRepository, CurrentUserRepository>();
        
        services.AddEmailService(openApiInfo);
    }
}