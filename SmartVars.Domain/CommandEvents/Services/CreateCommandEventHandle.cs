using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartVars.Domain.CommandEvent.Services.Interface;
using SmartVars.Domain.EventHandle.EmailEvent;
using SmartVars.Domain.EventHandle.RepositoryHttp.Interfaces;

namespace SmartVars.Domain.CommandEvent.Services
{
    public class CreateCommandEventHandle : IEventHandle<CreateEventHandle>
    {
        private readonly ILogger<CreateCommandEventHandle> _logger;
        private readonly IConfiguration _config;
        private readonly ISendEmailEvent _sendEmailEvent;
        private bool _disposed = false;

        public CreateCommandEventHandle(ILogger<CreateCommandEventHandle> logger, IConfiguration configuration, ISendEmailEvent sendEmailEvent)
        {
            _logger = logger;
            _config = configuration;
            _sendEmailEvent = sendEmailEvent;
        }

        public async Task Handle(CreateEventHandle @event)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var emailFrom = _config["Email:EmailFrom"];

            var sendEmail = new EmailEventHandle(apiKey, emailFrom, _sendEmailEvent);

            _logger.LogInformation($"Event Name: {@event.EventName}, ID: {@event.EventId}, Message: {@event.Message}, DateTime: {@event.DateTimeEvent}, Var ID: {@event.VarId}");

            await sendEmail.SendEmail(
                new List<string> { "flaviasampaio1991.martins@gmail.com" },
                "Tell me if you get this email",
                @event
            );

            await Task.CompletedTask;
        }
        #region
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sendEmailEvent?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
