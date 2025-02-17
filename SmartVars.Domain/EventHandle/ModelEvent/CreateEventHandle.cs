using SmartVars.Domain.Entities;

public class CreateEventHandle
{
    public string Message { get; set; }
    public Guid EventId { get; set; }
    public DateTime DateTimeEvent { get; set; }
    public string EventName { get; set; }
    public int VarId { get; set; }

    public CreateEventHandle()
    {
        Message = "Created or Modified";
        EventId = Guid.NewGuid();
        DateTimeEvent = DateTime.Now;
        EventName = "create";
    }

    public CreateEventHandle(BuildingVars buildingVars)
    {
        if (buildingVars == null)
        {
            throw new ArgumentNullException(nameof(buildingVars), "BuildingVars cannot be null.");
        }

        Message = "New variable created";
        EventId = Guid.NewGuid();
        DateTimeEvent = DateTime.Now;
        EventName = $"VarCreated: {buildingVars.Id}";
        VarId = buildingVars.Id;
    }
}