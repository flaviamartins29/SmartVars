using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SmartVars.Domain.EventHandle.RepositoryHttp.Interfaces;

namespace SmartVars.Infra.Http.HttpRepository
{
    public class SendEmailEvent : ISendEmailEvent
    {
        private bool _disposed = false;
        private readonly IConfiguration _config;

        public SendEmailEvent(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailBySendGridAsync(SendGridMessage message)
        {

            var apiKey = _config["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var response = await client.SendEmailAsync(message);
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {response.StatusCode}");
            }
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _disposed = false;
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
