using backendEventec.UserManagement.Domain.Model.Commands;

namespace backendEventec.UserManagement.Domain.Model.Aggregates;

public class Organizer
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public int UserId { get; private set; }
    public int EventsInCharge { get; private set; }
    
    protected Organizer()
    {
        this.CompanyId = 0;
        this.UserId = 0;
        this.EventsInCharge = 0;
    }

    public Organizer(CreateOrganizerCommand command)
    {
        this.UserId = command.UserId;
    }
}