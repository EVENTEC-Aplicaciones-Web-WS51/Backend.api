namespace backendEventec.EventAndTicketing.Domain.Model.Commands;

public record CreateEventCommand(string Name, string Description, string Status);