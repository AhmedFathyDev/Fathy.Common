namespace Fathy.Common.Email;

public class Message
{
    public Message(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }

    public string To { get; }
    public string Subject { get; }
    public string Body { get; }
    public bool IsBodyHtml { get; set; }
}