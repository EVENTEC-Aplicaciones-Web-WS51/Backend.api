using backendEventec.EventAndTicketing.Domain.Model.Commands;

namespace backendEventec.EventAndTicketing.Domain.Model.Aggregates;

public class Ticket
{
    public int Id { get; private set; }
    public int EventId { get; private set; }
    public int ClientId { get; private set; }
    public int Price { get; private set; }
    public string Category { get; private set; }

    protected Ticket()
    {
        this.EventId = 0;
        this.ClientId = 0;
        this.Price = 0;
        this.Category = string.Empty;

    }
    public Ticket(CreateTicketCommand command)
    {
        
        this.Price = command.Price;
        this.Category = command.Category;

    }
}