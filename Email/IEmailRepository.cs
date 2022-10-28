using Fathy.Startup;

namespace Fathy.Email;

public interface IEmailRepository
{
    Task<Response> SendAsync(Message message);
}