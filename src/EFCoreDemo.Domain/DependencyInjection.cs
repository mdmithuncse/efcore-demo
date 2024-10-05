using EFCoreDemo.Domain.Abstractions;
using EFCoreDemo.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreDemo.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, 
            IConfiguration configuration) => 
            services
                .AddDatabase(configuration);

        private static IServiceCollection AddDatabase(this IServiceCollection services, 
            IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseNpgsql(connectionString, npgsqlOptions =>
                        npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
                    .UseSnakeCaseNamingConvention());

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}