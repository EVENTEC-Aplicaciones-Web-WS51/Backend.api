namespace backendEventec.UserManagement.Interfaces.REST.Resources;

public record CreateUserResource(string FirstName,string LastName, string Address, string Email, string Phone, string Password);