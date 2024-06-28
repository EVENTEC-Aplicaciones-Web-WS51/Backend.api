namespace BDEventecFinal.userManagement.Domain.Model.Commands;

public record CreateUserCommand(string FirstName,string LastName,string Address,string Email, string Phone, string Password,string Role);
