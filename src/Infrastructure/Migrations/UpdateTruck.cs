using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011839)]
    public class UpdateTruck : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_Update_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_Update.sql");
        }
    }
}
