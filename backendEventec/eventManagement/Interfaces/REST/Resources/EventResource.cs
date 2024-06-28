namespace backendEventec.eventManagement.Interfaces.REST.Resources;

public record EventResource(int IdEvent,string NameEvent,string Type, string Description, int TotalTicket, string Status);