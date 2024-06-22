using backendEventec.UserManagement.Domain.Model.Commands;

namespace backendEventec.UserManagement.Domain.Model.Aggregates;

public class Client
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    

    protected Client()
    {
        this.UserId = 0;
    }

    public Client(CreateClientCommand command)
    {
        this.UserId = command.UserId;
    }
}