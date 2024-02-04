using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402012111)]
    public class GetFilteredAndSorted : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_GetFilteredAndSorted_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_GetFilteredAndSorted.sql");
        }
    }
}
