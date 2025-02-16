using Abp.Events.Bus.Handlers;
using Microsoft.Extensions.Logging;

namespace SmartVars.Domain.EventHandle.Service;
public class DeleteCommandEventHandle : IEventHandler
{
    private readonly ILogger<DeleteCommandEventHandle> _logger;

    public DeleteCommandEventHandle(ILogger<DeleteCommandEventHandle> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CreateEventHandle @event)
    {

        _logger.LogInformation($"Var with ID {@event.EventId} was deleted.");
    }
}
