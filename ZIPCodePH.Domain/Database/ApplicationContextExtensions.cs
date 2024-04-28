using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZIPCodePH.DataContext.Database;

public static class ApplicationContextExtensions
{
    public static IServiceCollection AddApplicationContext(
        this IServiceCollection services,
        string? connectionString = null)
    {
        if (connectionString is null)
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = ".";
            builder.InitialCatalog = "ZIPCodePH";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;
            builder.ConnectTimeout = 30;
            builder.IntegratedSecurity = true;
            connectionString = builder.ConnectionString;
        }

        services.AddDbContext<ApplicationContext>(
            options =>
            {
                options.UseSqlServer(connectionString);
                options.LogTo(Console.WriteLine,
                    new[]
                    {
                        Microsoft.EntityFrameworkCore
                            .Diagnostics.RelationalEventId
                            .CommandExecuting
                    });
            },
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient);
        return services;
    }
}