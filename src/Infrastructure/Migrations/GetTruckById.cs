using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011837)]
    public class GetTruckById : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_GetById_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_GetById.sql");
        }
    }
}
