using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartVars.Domain.EventHandle.CommandEvent.Services.Interface;
using SmartVars.Domain.EventHandle.EmailEvent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartVars.Domain.EventHandle.CommandEvent.Services
{
    public class CreateCommandEventHandle : IEventHandle<CreateEventHandle>
    {
        private readonly ILogger<CreateCommandEventHandle> _logger;
        private readonly IConfiguration _config;

        public CreateCommandEventHandle(ILogger<CreateCommandEventHandle> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public async Task Handle(CreateEventHandle @event)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var emailFrom = _config["Email:EmailFrom"];

            var sendEmail = new EmailNotifications(apiKey, emailFrom);

            _logger.LogInformation($"Event Name: {@event.EventName}, ID: {@event.EventId}, Message: {@event.Message}, DateTime: {@event.DateTimeEvent}, Var ID: {@event.VarId}");

            await sendEmail.SendEmail(
                new List<string> { "esleygnr@gmail.com", "flavia.martins1991@hotmail.com" },
                "ME AVISA SE VC RECEBEU",
                @event
            );

            await Task.CompletedTask;
        }
    }
}
