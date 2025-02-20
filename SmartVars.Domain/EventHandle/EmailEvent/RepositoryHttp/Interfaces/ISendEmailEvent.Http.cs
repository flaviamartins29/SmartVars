using SendGrid.Helpers.Mail;

namespace SmartVars.Domain.EventHandle.RepositoryHttp.Interfaces
{
    public interface ISendEmailEvent : IDisposable
    {
        Task SendEmailBySendGridAsync(SendGridMessage message);
    }
}
