using SmartVars.Domain.Entities;

namespace SmartVars.Domain.EventHandle.Service;
public class CreateEventHandle
{
    public string Message { get; set; }
    public Guid EventId { get; set; }
    public DateTime DateTimeEvent { get; set; }
    public string EventName { get; set; }
    public int VarId { get; set; }  

    public CreateEventHandle()
    {
        Message = "Created or Modificate";
        EventId = Guid.NewGuid();
        DateTimeEvent = DateTime.Now;
        EventName = "create";
    }

    public CreateEventHandle(BuildingVars buildingVars)
    {
        Message = "New variable created";
        EventId = Guid.NewGuid();
        DateTimeEvent = DateTime.Now;
        EventName = $"VarCreated: {buildingVars.Id}";
        VarId = buildingVars.Id;
    }
}
