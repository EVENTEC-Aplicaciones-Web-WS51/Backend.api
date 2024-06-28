namespace backendEventec.paymethods.Interfaces.REST.Resources;

public record CardResource(int Id, int IdWallet, string Number, string DueDate, string CssCode);