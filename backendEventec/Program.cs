
using Backend_MyEventec.EventAndTicketing.Infraestructure.Persistence.EFC.Repositories;
using backendEventec.EventAndTicketing.Application.Internal.CommandServices;
using backendEventec.EventAndTicketing.Application.Internal.QueryServices;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.EventAndTicketing.Domain.Services;
using backendEventec.EventAndTicketing.Infraestructure.Persistence.EFC.Repositories;
using backendEventec.Shared.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo()
            {
                Title = "Eventec.io",
                Version = "v1",
                Description = "Eventecs",
                TermsOfService = new Uri("https://Eventec.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = " Eventec.io",
                    Email = "contact@Eventec.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase Urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Add this line

//Ticket Bounded Context Injection Configuration
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketCommandService, TicketCommandService>();
builder.Services.AddScoped<ITicketQueryService, TicketQueryService>();
// Event Bounded Context Injection Configuration
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventCommandService, EventCommandService>();
builder.Services.AddScoped<IEventQueryService, EventQueryService>();


var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();