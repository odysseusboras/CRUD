using Data.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Data.Context
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                databaseService.CreateDatabase("CRUD");


                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                migrationService.ListMigrations();
                migrationService.MigrateUp();
            }
            return host;
        }
    }
}
