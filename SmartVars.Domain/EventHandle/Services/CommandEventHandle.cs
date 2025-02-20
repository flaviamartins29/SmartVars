using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using SmartVars.Domain.CommandEvent.Services.Interface;
using SmartVars.Domain.EventHandle.Service.Interfaces;

namespace SmartVars.Domain.EventHandle.Service
{
    public class CommandEventHandle<TEvent> : ICommandEventHandle<TEvent>
    {
        private bool _disposed = false;
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
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_serviceProvider is IDisposable disposableServiceProvider)
                    {
                        disposableServiceProvider.Dispose();
                    }
                }
                // Libere recursos não gerenciados, se houver

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
