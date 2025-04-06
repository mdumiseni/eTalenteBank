using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineBanking.Application.Interfaces;
using OnlineBanking.Persistence.EntityFramework;
using OnlineBanking.Persistence.Services;

namespace OnlineBanking.Persistence;

public static class InfrastructureServiceCollection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                                 ?? throw new ApplicationException(
                                     "The 'DefaultConnection' connection string is missing or empty."))
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    
                });
        });
        services.AddHttpContextAccessor();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}