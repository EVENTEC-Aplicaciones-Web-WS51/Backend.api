namespace backendEventec.UserManagement.Interfaces.REST.Resources;

public record CreateOrganizerResource(int UserId,string CompanyName,int EventsInCharge);