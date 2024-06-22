using backendEventec.paymethods.Domain.Model.Commands;

namespace backendEventec.paymethods.Domain.Model.Aggregates;

public class Wallet
{
    public int Id { get; private set; }
    public int QuantityCard { get; private set; }
    public DateTime CreationDate { get; private set; }
    public int UserId { get; private set; }
    protected Wallet()
    {
        this.QuantityCard = 0;
        this.CreationDate = DateTime.UtcNow;
    }

    public Wallet(CreateWalletCommand command)
    {
        this.QuantityCard = command.QuantityCard;
        this.UserId = command.UserId;
    }
}