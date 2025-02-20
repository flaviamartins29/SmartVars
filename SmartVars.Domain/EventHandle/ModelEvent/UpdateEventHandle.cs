using SmartVars.Domain.Entities;

namespace SmartVars.Domain.EventHandle.Service
{
    public class UpdateEventHandle
    {
        public string Message { get; set; }
        public Guid EventId { get; set; }
        public DateTime DateTimeEvent { get; set; }
        public string EventName { get; set; }
        public int VarId { get; set; }

        public UpdateEventHandle()
        {
            Message = "Created or Modified";
            EventId = Guid.NewGuid();
            DateTimeEvent = DateTime.Now;
            EventName = "create";
        }

        public UpdateEventHandle(BuildingVars buildingVars)
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
}