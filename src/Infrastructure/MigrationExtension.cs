using FluentMigrator.Runner;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class MigrationExtension
    {
        public static IServiceProvider Migrate(this IServiceProvider app)
        {
            var dbService = app.GetRequiredService<DatabaseService>();
            dbService.EnsureDatabaseExists();

            using var serviceScope = app.CreateScope();
            var services = serviceScope.ServiceProvider;
            var runner = services.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();

            return app;
        }
    }
}
