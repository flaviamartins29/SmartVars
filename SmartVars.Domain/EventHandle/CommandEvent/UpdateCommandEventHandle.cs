using Abp.Events.Bus.Handlers;
using Microsoft.Extensions.Logging;

namespace SmartVars.Domain.EventHandle.Service;
public class UpdateCommandEventHandle : IEventHandler
{
    private readonly ILogger<UpdateCommandEventHandle> _logger;

    public UpdateCommandEventHandle(ILogger<UpdateCommandEventHandle> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CreateEventHandle @event)
    {
        // Lógica para lidar com o evento
        _logger.LogInformation($"Var with ID {@event} was updated.");
    }
}