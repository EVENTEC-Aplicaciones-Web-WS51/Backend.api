    using backendEventec.CenterManagement.Domain.Model.Commands;

    namespace backendEventec.CenterManagement.Domain.Model.Aggregates;

    public class Place
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Capacity { get; private set; }
        public int Ruc { get; private set; }

        protected Place()
        {
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Capacity = int.MaxValue;
            this.Ruc = int.MaxValue;
        }

        public Place(CreatePlaceCommand command)
        {
            this.Name = command.Name;
            this.Address = command.Address;
            this.Capacity = command.Capacity;
            this.Ruc = command.Ruc;
        }
    }