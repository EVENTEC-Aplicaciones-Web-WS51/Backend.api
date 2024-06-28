using backendEventec.CenterManagement.Domain.Model.Commands;

namespace backendEventec.CenterManagement.Domain.Model.Aggregates
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int IdPlace { get; private set; }
        public int QuantityOrganizer { get; private set; }

        protected Company()
        {
            this.Name = string.Empty;
            this.IdPlace = 0;
            this.QuantityOrganizer = int.MaxValue;

        }
        public Company(CreateCompanyCommand command)
        {
            this.Name = command.Name;
            this.QuantityOrganizer = command.QuantityOrganizer;
        }
    }
}