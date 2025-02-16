using Abp.Events.Bus.Handlers;
using Microsoft.Extensions.DependencyInjection;


namespace SmartVars.Domain.EventHandle.Service.Interfaces
{
    public interface ICommandEventHandle<TEvent>
    {
        Task Dispatch<T>(T @event);
    }


}