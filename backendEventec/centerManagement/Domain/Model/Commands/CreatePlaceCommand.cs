namespace backendEventec.CenterManagement.Domain.Model.Commands;

public record CreatePlaceCommand(string Name, string Address, int Capacity, int Ruc );