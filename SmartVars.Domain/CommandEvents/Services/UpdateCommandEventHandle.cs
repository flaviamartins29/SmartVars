using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartVars.Domain.CommandEvent.Services.Interface;
using SmartVars.Domain.EventHandle.EmailEvent;
using SmartVars.Domain.EventHandle.RepositoryHttp.Interfaces;

namespace SmartVars.Domain.CommandEvent.Services;
public class UpdateCommandEventHandle : IEventHandle<CreateEventHandle>
{
    private readonly ILogger<UpdateCommandEventHandle> _logger;
    private readonly IConfiguration _config;
    private readonly ISendEmailEvent _sendEmailEvent;
    private bool _disposed = false;

    public UpdateCommandEventHandle(ILogger<UpdateCommandEventHandle> logger, IConfiguration configuration, ISendEmailEvent sendEmailEvent)
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

        _logger.LogInformation($"Var with ID {@event} was updated.");

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
