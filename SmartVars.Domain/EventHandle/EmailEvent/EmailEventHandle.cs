using SendGrid.Helpers.Mail;
using SmartVars.Domain.EventHandle.RepositoryHttp.Interfaces;

namespace SmartVars.Domain.EventHandle.EmailEvent
{
    public class EmailEventHandle
    {
        private readonly string _apiKey;
        private readonly string _emailFrom;
        private readonly ISendEmailEvent _sendEmailEvent;

        public EmailEventHandle(string apiKey, string emailFrom, ISendEmailEvent sendEmailEvent)
        {
            _apiKey = apiKey ?? throw new ArgumentException(nameof(apiKey));
            _emailFrom = emailFrom ?? throw new ArgumentException(nameof(emailFrom));
            _sendEmailEvent = sendEmailEvent;
        }

        public async Task SendEmail(List<string> emailsTo, string subject, CreateEventHandle createEventHandle)
        {
            try
            {
                var message = PrepareMessage(emailsTo, subject, createEventHandle);
                await _sendEmailEvent.SendEmailBySendGridAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex}");
                throw;
            }
        }

        private SendGridMessage PrepareMessage(List<string> emailsTo, string subject, CreateEventHandle createEventHandle)
        {
            var from = new EmailAddress(_emailFrom, "Seu Nome");
            var plainTextContent = createEventHandle.ToString();
            var htmlContent = $"<p>{createEventHandle.ToString()}</p>";

            var message = new SendGridMessage
            {
                From = from,
                Subject = subject,
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent
            };

            foreach (var email in emailsTo)
            {
                message.AddTo(new EmailAddress(email));
            }

            return message;
        }
    }
}
