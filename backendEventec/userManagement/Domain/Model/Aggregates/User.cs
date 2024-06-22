using backendEventec.UserManagement.Domain.Model.Commands;

namespace backendEventec.UserManagement.Domain.Model.Aggregates;

public class User
{
    public int Id { get; private set; }
    public int IdWallet { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? SuspensionDate { get; private set; }

    protected User()
    {
        this.IdWallet = 0;
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Address = string.Empty;
        this.Email = string.Empty;
        this.Phone = string.Empty;
        this.Password = string.Empty;
        this.CreationDate = DateTime.UtcNow;
        this.SuspensionDate = null;
    }

    public User(CreateUserCommand command)
    {
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        this.Address = command.Address;
        this.Email = command.Email;
        this.Phone = command.Phone;
        this.Password = command.Password;

    }
}