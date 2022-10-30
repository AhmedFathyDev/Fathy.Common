using Fathy.Common.Startup;

namespace Fathy.Common.Auth.Admin.Repositories;

public interface IAdminRepository
{
    Task<Response> AddToRoleAsync(string userEmail, string role);
    Task<Response> CreateRoleAsync(string role);
}