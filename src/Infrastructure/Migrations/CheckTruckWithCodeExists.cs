using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011913)]
    public class CheckTruckWithCodeExists : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_CheckTruckWithCodeExists_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_CheckTruckWithCodeExists.sql");
        }
    }
}
