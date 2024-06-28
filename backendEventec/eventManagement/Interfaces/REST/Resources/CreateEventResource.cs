namespace backendEventec.eventManagement.Interfaces.REST.Resources;

public record CreateEventResource(string NameEvent,string Type, string Description, int TotalTicket, string Status);