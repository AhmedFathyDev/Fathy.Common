using Fathy.Common.Startup;

namespace Fathy.Common.Auth.Admin.Repositories;

public interface IAdminRepository
{
    Task<Response> CreateRoleAsync(string role);
    Task<Response> AddToRoleAsync(string userEmail, string role);
}