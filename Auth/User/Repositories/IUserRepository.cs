using Fathy.Common.Auth.User.DTOs;
using Fathy.Common.Startup;

namespace Fathy.Common.Auth.User.Repositories;

public interface IUserRepository
{
    Task<Response> ConfirmEmailAsync(string userEmail, string token);
    Task<Response> CreateAsync(UserDto userDto);
    Task<Response> DeleteAsync(UserDto userDto);
    Task<Response> SendConfirmationEmailAsync(string userEmail);
    Task<Response<string>> SignInAsync(UserDto userDto);
}