using backendEventec.EventAndTicketing.Domain.Model.Commands;

namespace backendEventec.EventAndTicketing.Domain.Model.Aggregates;

public class Event {
    public int Id { get; private set; }
    public int IdHeadquarters{ get; private set; }
    public int IdOrganizer { get; private set; }
    public string Name{ get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime FinishDate { get; private set; }
    public string Description { get; private set; }
    public int TotalTicket { get; private set; }
    public string Status { get; private set; }

    protected Event()
    {
        this.IdHeadquarters = 0;
        this.IdOrganizer = 0;
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Status = string.Empty;
        this.TotalTicket = int.MaxValue;
        this.StartDate = DateTime.UtcNow;
        this.FinishDate = DateTime.Now.AddDays(1);
    }

    public Event(CreateEventCommand command)
    {
        
        this.Name = command.Name;
        this.Description = command.Description;
        this.Status = command.Status;
        
    }
}