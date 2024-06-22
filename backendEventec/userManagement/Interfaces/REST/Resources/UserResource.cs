namespace backendEventec.UserManagement.Interfaces.REST.Resources;

public record UserResource(int Id, int IdWallet, string FirstName, string LastName, string Address, string Email, string Phone, DateTime CreationDate, DateTime? SuspensionDate);