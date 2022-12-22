using MedicationPlan.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicationPlan.Api.AppConfiguration.ServicesExtensions;

public static partial class ServicesExtensions
{
    public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Context");
        services.AddDbContext<Context>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString, sqlServerOption =>
                {
                    sqlServerOption.CommandTimeout(60 * 60); // 1 hour
                });

        });
    }
}


