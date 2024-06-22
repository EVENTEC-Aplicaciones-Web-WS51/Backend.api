using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.paymethods.Domain.Model.Aggregates;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backendEventec.UserManagement.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Card Context
            builder.Entity<Card>().ToTable("Card");
            builder.Entity<Card>().HasKey(c => c.Id);
            builder.Entity<Card>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Card>().Property(c => c.IdWallet).IsRequired();
            builder.Entity<Card>().Property(c => c.Number).IsRequired();
            builder.Entity<Card>().Property(c => c.DueDate).IsRequired();
            builder.Entity<Card>().Property(c => c.CssCode).IsRequired();

            // Wallet Context
            builder.Entity<Wallet>().ToTable("Wallet");
            builder.Entity<Wallet>().HasKey(w => w.Id);
            builder.Entity<Wallet>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(w => w.QuantityCard).IsRequired();
            builder.Entity<Wallet>().Property(w => w.CreationDate).IsRequired();
            builder.Entity<Wallet>().Property(w => w.UserId).IsRequired();

            // Place Context
            builder.Entity<Place>().ToTable("Place");
            builder.Entity<Place>().HasKey(e => e.Id);
            builder.Entity<Place>().Property(e => e.Name).IsRequired();
            builder.Entity<Place>().Property(e => e.Address).IsRequired();
            builder.Entity<Place>().Property(e => e.Capacity).IsRequired();
            builder.Entity<Place>().Property(e => e.Ruc).IsRequired();

            // Company Context
            builder.Entity<Company>().ToTable("Company");
            builder.Entity<Company>().HasKey(e => e.Id);
            builder.Entity<Company>().Property(e => e.Name).IsRequired();
            builder.Entity<Company>().Property(e => e.IdPlace).IsRequired();
            builder.Entity<Company>().Property(e => e.QuantityOrganizer).IsRequired();

            // Headquarters Context
            builder.Entity<Headquarters>().ToTable("Headquarters");
            builder.Entity<Headquarters>().HasKey(e => e.Id);
            builder.Entity<Headquarters>().Property(e => e.Name).IsRequired();
            builder.Entity<Headquarters>().Property(e => e.IdPlace).IsRequired();
            builder.Entity<Headquarters>().Property(e => e.Capacity).IsRequired();

            // User Context
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.IdWallet).IsRequired();
            builder.Entity<User>().Property(u => u.FirstName).IsRequired();
            builder.Entity<User>().Property(u => u.LastName).IsRequired();
            builder.Entity<User>().Property(u => u.Address).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.Phone).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();
            builder.Entity<User>().Property(u => u.CreationDate).IsRequired();
            builder.Entity<User>().Property(u => u.SuspensionDate).IsRequired(false);

            // Client Context
            builder.Entity<Client>().ToTable("Client");
            builder.Entity<Client>().HasKey(c => c.Id);
            builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(c => c.UserId).IsRequired();

            // Organizer Context
            builder.Entity<Organizer>().ToTable("Organizer");
            builder.Entity<Organizer>().HasKey(o => o.Id);
            builder.Entity<Organizer>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Organizer>().Property(o => o.CompanyId).IsRequired();
            builder.Entity<Organizer>().Property(o => o.UserId).IsRequired();
            builder.Entity<Organizer>().Property(o => o.EventsInCharge).IsRequired();
            
            // Event Context
            builder.Entity<Event>().ToTable("Event");
            builder.Entity<Event>().HasKey(e => e.Id);
            builder.Entity<Event>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Event>().Property(e => e.IdHeadquarters).IsRequired();
            builder.Entity<Event>().Property(e => e.IdOrganizer).IsRequired();
            builder.Entity<Event>().Property(e => e.Name).IsRequired();
            builder.Entity<Event>().Property(e => e.StartDate).IsRequired();
            builder.Entity<Event>().Property(e => e.FinishDate).IsRequired();
            builder.Entity<Event>().Property(e => e.Description).IsRequired();
            builder.Entity<Event>().Property(e => e.TotalTicket).IsRequired();
            builder.Entity<Event>().Property(e => e.Status).IsRequired();
        
            // Ticket Configuration
            builder.Entity<Ticket>().ToTable("Tickets");
            builder.Entity<Ticket>().HasKey(t => t.Id);
            builder.Entity<Ticket>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ticket>().Property(t => t.EventId).IsRequired();
            builder.Entity<Ticket>().Property(t => t.ClientId).IsRequired();
            builder.Entity<Ticket>().Property(t => t.Price).IsRequired();
            builder.Entity<Ticket>().Property(t => t.Category).IsRequired();
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
