using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011909)]
    public class UpdateTruckStatus : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_UpdateStatus_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_UpdateStatus.sql");
        }
    }
}
