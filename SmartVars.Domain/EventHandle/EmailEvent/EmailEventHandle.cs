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
            var from = new EmailAddress(_emailFrom, "Flavia Martins");
            var subjectEmail = "News from API Smart Vars";
            var plainTextContent = createEventHandle.GetType();
            var htmlContent = "<H1>Have a new var add or update </H1>" +
                              $"<p><B>Event:</B> {createEventHandle.EventName}</p>" +
                              $"<p><B>Message:</B> {createEventHandle.Message}</p>" +
                              $"<p><B>VarId:</B> {createEventHandle.VarId}</p>" +
                              $"<p><B>Date:</B> {createEventHandle.DateTimeEvent}</p>";

            var message = new SendGridMessage
            {
                From = from,
                Subject = subjectEmail,
                PlainTextContent = plainTextContent.Attributes.ToString(),
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
