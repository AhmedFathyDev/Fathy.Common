using Fathy.Auth.User.DTOs;
using Fathy.Startup;

namespace Fathy.Auth.User.Repositories;

public interface IUserRepository
{
    Task<Response> CreateAsync(UserDto userDto);
    Task<Response<string>> SignInAsync(UserDto userDto);
    Task<Response> SendConfirmationEmailAsync(string userEmail);
    Task<Response> ConfirmEmailAsync(string userEmail, string token);
    Task<Response> DeleteAsync(UserDto userDto);
}