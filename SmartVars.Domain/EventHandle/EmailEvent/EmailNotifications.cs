using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartVars.Domain.EventHandle.EmailEvent
{
    public class EmailNotifications
    {
        private readonly string _apiKey;
        private readonly string _emailFrom;

        public EmailNotifications(string apiKey, string emailFrom)
        {
            _apiKey = apiKey ?? throw new ArgumentException(nameof(apiKey));
            _emailFrom = emailFrom ?? throw new ArgumentException(nameof(emailFrom));
        }

        public async Task SendEmail(List<string> emailsTo, string subject, CreateEventHandle createEventHandle)
        {
            try
            {
                var message = PrepareMessage(emailsTo, subject, createEventHandle);
                await SendEmailBySendGridAsync(message);
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
            //var subject = subject;
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

        private async Task SendEmailBySendGridAsync(SendGridMessage message)
        {
            var client = new SendGridClient(_apiKey);
            var response = await client.SendEmailAsync(message);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {response.StatusCode}");
            }
        }
    }
}
