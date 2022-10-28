using Fathy.Startup;

namespace Fathy.Auth.Admin.Repositories;

public interface IAdminRepository
{
    Task<Response> CreateRoleAsync(string role);
    Task<Response> AddToRoleAsync(string userEmail, string role);
}