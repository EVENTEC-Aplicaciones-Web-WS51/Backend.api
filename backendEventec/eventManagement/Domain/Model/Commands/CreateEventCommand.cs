namespace BDEventecFinal.eventManagement.Domain.Model.Commands;

public record CreateEventCommand(string NameEvent,string Type, string Description, int TotalTicket, string Status);