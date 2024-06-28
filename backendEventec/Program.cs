using backendEventec.CenterManagement.Application.Internal.CommandServices;
using backendEventec.CenterManagement.Application.Internal.QueriesServices;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;
using backendEventec.CenterManagement.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.eventManagement.Application.Internal.CommandServices;
using backendEventec.eventManagement.Application.Internal.QueriesServices;
using backendEventec.eventManagement.Domain.Repositories;
using backendEventec.eventManagement.Domain.Services;
using backendEventec.eventManagement.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.IAM.Application.Internal.CommandServices;
using backendEventec.IAM.Domain.Repositories;
using backendEventec.IAM.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.Shared.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.paymethods.Application.Internal.CommandServices;
using backendEventec.paymethods.Application.Internal.QueriesServices;
using backendEventec.paymethods.Domain.Repositories;
using backendEventec.paymethods.Domain.Services;
using backendEventec.paymethods.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.userManagement.Application.Internal.CommandServices;
using backendEventec.userManagement.Application.Internal.QueriesServices;
using backendEventec.userManagement.Domain.Repositories;
using backendEventec.userManagement.Infrastructure.Persistence.EFC.Repositories;
using BDEventecFinal.IAM.Application.Internal.OutboundServices;
using BDEventecFinal.IAM.Domain.Services;
using BDEventecFinal.IAM.Infrastructure.Hashing.BCrypt.Services;
using BDEventecFinal.IAM.Infrastructure.Tokens.JWT.Configuration;
using BDEventecFinal.IAM.Infrastructure.Tokens.JWT.Services;
using BDEventecFinal.userManagement.Domain.Services;
using Microsoft.AspNetCore.Authentication;
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
                Description = "Eventec",
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

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Add this line

// User Bounded Context Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
// Wallet Bounded Context Injection Configuration
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IWalletCommandService, WalletCommandService>();
builder.Services.AddScoped<IWalletQueryService, WalletQueryService>();

// Card Bounded Context Injection Configuration
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardCommandService, CardCommandService>();
builder.Services.AddScoped<ICardQueryService, CardQueryService>();

// Place, Company, and Headquarters Bounded Context Injection Configuration
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceCommandService, PlaceCommandService>();
builder.Services.AddScoped<IPlaceQueryService, PlaceQueryService>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyCommandService, CompanyCommandService>();
builder.Services.AddScoped<ICompanyQueryService, CompanyQueryService>();

builder.Services.AddScoped<IHeadquartersRepository, HeadquartersRepository>();
builder.Services.AddScoped<IHeadquartersCommandService, HeadquartersCommandService>();
builder.Services.AddScoped<IHeadquartersQueryService, HeadquartersQueryService>();

// Event Bounded Context Injection Configuration
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventCommandService, EventCommandService>();
builder.Services.AddScoped<IEventQueryService, EventQueryService>();

builder.Services.AddScoped<IUserIamRepository, UserIamRepository>(); // Add this line
builder.Services.AddScoped<IUserIamCommandService, UserIamCommandService>();
builder.Services.AddScoped<ITokenService, TokenService>(); // Add this line
builder.Services.AddScoped<IHashingService, HashingService>(); // Add this line
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<AuthenticationService>();
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
