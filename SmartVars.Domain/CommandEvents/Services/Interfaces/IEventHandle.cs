namespace SmartVars.Domain.CommandEvent.Services.Interface
{
    public interface IEventHandle<in TEvent> : IDisposable
    {
        Task Handle(TEvent @event);
    }
}
