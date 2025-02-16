using Abp.Events.Bus.Handlers;
using Microsoft.Extensions.Logging;
using SmartVars.Domain.EventHandle;

namespace SmartVars.Domain.EventHandle.Service;
public class CreatedEventHandler : IEventHandler
{
    private readonly ILogger<CreatedEventHandler> _logger;

    public CreatedEventHandler(ILogger<CreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CreateEventHandle @event)
    {
        // Lógica para lidar com o evento
        _logger.LogInformation($"Var with ID {@event} was created.");
    }
}
