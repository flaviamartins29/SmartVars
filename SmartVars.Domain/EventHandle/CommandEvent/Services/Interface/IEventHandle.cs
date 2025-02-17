using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Domain.EventHandle.CommandEvent.Services.Interface
{
    public interface IEventHandle<in TEvent>
    {
        Task Handle(TEvent @event);
    }
}
