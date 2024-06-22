namespace backendEventec.paymethods.Domain.Model.Commands
{
    public record CreateCardCommand(string Number, string DueDate, string CssCode);
}