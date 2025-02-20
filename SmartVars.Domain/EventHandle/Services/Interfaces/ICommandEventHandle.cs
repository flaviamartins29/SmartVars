
namespace SmartVars.Domain.EventHandle.Service.Interfaces
{
    public interface ICommandEventHandle<in TEvent> : IDisposable
    {
        Task Dispatch(TEvent @event);
    }
}