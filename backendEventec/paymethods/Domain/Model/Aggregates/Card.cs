using backendEventec.paymethods.Domain.Model.Commands;

namespace backendEventec.paymethods.Domain.Model.Aggregates
{
    public class Card
    {
        public int Id { get; private set; }
        public int IdWallet { get; private set; }
        public string Number { get; private set; }
        public string DueDate { get; private set; }
        public string CssCode { get; private set; }

        protected Card()
    {
        this.IdWallet = 0;
        this.Number = string.Empty;
        this.DueDate = string.Empty;
        this.CssCode = string.Empty;
    }

        public Card(CreateCardCommand command)
    {
        this.Number = command.Number;
        this.CssCode = command.CssCode;
        this.DueDate = command.DueDate;
    }
    
    }
}