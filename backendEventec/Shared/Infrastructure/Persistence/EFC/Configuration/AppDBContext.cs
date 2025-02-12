using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pcWeb2.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Begin BoundedContext Model
        // PurchaseOrders Context
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}