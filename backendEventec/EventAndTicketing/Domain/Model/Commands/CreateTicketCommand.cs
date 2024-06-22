namespace backendEventec.EventAndTicketing.Domain.Model.Commands;

public record CreateTicketCommand(int Price, string Category);