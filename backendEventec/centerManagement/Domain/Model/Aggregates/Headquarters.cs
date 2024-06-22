using backendEventec.CenterManagement.Domain.Model.Commands;

namespace backendEventec.CenterManagement.Domain.Model.Aggregates;

public class Headquarters
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int IdPlace { get; private set; }
    public int Capacity { get; private set; }
    
    protected Headquarters()
    {
        this.Name = string.Empty;
        this.IdPlace = 0;
        this.Capacity = int.MaxValue;
    }

    public Headquarters(CreateHeadquartersCommand command)
    {
        this.Name = command.Name;
        this.Capacity = command.Capacity;
    }
}