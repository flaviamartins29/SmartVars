
namespace SmartVars.Domain.EventHandle.Service.Interfaces
{
    public interface ICommandEventHandle<in TEvent>
    {
        Task Dispatch(TEvent @event);
    }
}