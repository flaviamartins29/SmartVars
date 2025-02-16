using Abp.Events.Bus.Handlers;
using Microsoft.Extensions.DependencyInjection;
using SmartVars.Domain.EventHandle.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Domain.EventHandle.Service
{
    public class CommandEventHandle : ICommandEventHandle<CreateEventHandle>
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandEventHandle(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Dispatch<TEvent>(TEvent @event)
        {
            var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();
            foreach (var handler in handlers)
            {
                handler.HandleEvent(@event);
            }
        }
    }
}