using Fathy.Common.Startup;

namespace Fathy.Common.Email;

public interface IEmailRepository
{
    Task<Response> SendAsync(Message message);
}