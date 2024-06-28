using BDEventecFinal.eventManagement.Domain.Model.Commands;

namespace BDEventecFinal.eventManagement.Domain.Model.Aggregates;

public class Event: EventAudit
{
    public int IdEvent { get; private set; }
    public string NameEvent { get; private set; }
    public string Type { get; private set; }
    public string Description { get; private set; }
    public int TotalTicket { get; private set; }
    public string Status { get; private set; }

    protected Event()
    {
        this.NameEvent = string.Empty;
        this.Type = string.Empty;
        this.Description = string.Empty;
        this.TotalTicket = 0;
        this.Status = string.Empty;
    }
    public Event(CreateEventCommand command)
    {
        this.NameEvent = command.NameEvent;
        this.Type = command.Type;
        this.Description = command.Description;
        this.TotalTicket = command.TotalTicket;
        this.Status = command.Status;

    }
}