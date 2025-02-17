using Microsoft.Extensions.Logging;
using SmartVars.Domain.EventHandle.CommandEvent.Services.Interface;

namespace SmartVars.Domain.EventHandle.CommandEvent.Services;
public class UpdateCommandEventHandle : IEventHandle<CreateEventHandle>
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