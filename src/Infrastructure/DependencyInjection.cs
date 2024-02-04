using Domain.Abstractions;
using FluentMigrator.Runner;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ITruckRepository, TruckRepository>();

            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                var connectionString = configuration.GetConnectionString("truckDb") ??
                                       throw new ApplicationException("Connection string not provided.");

                return new SqlConnectionFactory(connectionString);
            });

            services.AddSingleton<DatabaseService>();

            services.AddFluentMigratorCore()
                .ConfigureRunner(config => config
                .AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("truckDb"))
                .ScanIn(typeof(DependencyInjection).Assembly).For.Migrations().For.EmbeddedResources())
                .AddLogging(config => config.AddFluentMigratorConsole());

            return services;
        }
    }
}
