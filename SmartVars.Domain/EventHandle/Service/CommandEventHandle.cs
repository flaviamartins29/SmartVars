using Microsoft.Extensions.DependencyInjection;
using SmartVars.Domain.EventHandle.CommandEvent.Services.Interface;
using SmartVars.Domain.EventHandle.Service.Interfaces;

namespace SmartVars.Domain.EventHandle.Service
{
    public class CommandEventHandle<TEvent> : ICommandEventHandle<TEvent>
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandEventHandle(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Dispatch(TEvent @event)
        {
            var handlers = _serviceProvider.GetServices<IEventHandle<TEvent>>();
            foreach (var handler in handlers)
            {
                await handler.Handle(@event);
            }
        }
    }
}