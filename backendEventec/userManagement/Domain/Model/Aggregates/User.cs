using BDEventecFinal.userManagement.Domain.Model.Commands;


namespace BDEventecFinal.userManagement.Domain.Model.Aggregates;

public class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    protected User()
    {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Address = string.Empty;
        this.Email = string.Empty;
        this.Phone = string.Empty;
        this.Password = string.Empty;
        this.Role = string.Empty;
        
    }

    public User(CreateUserCommand command)
    {
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        this.Address = command.Address;
        this.Email = command.Email;
        this.Phone = command.Phone;
        this.Password = command.Password;
        this.Role = command.Role;

    }
}