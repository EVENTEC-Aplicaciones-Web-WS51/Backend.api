using backendEventec.UserManagement.Domain.Model.Commands;

namespace backendEventec.UserManagement.Domain.Model.Aggregates;

public class Organizer
{
    public int Id { get; private set; }
    public string CompanyName { get; private set; }
    public int UserId { get; private set; }
    public int EventsInCharge { get; private set; }
    
    protected Organizer()
    {
        this.CompanyName = string.Empty;
        this.UserId = 0;
        this.EventsInCharge = 0;
    }

    public Organizer(CreateOrganizerCommand command)
    {
        this.CompanyName=command.CompanyName;
        this.UserId = command.UserId;
        this.EventsInCharge = command.EventsInCharge;
    }
}