using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011835)]
    public class DeleteTruck : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_Delete_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_Delete.sql");
        }
    }
}
