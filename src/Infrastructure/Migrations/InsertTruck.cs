using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011833)]
    public class InsertTruck : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spTruck_Insert_Rollback.sql");
        }

        public override void Up()
        {
            Execute.EmbeddedScript("spTruck_Insert.sql");
        }
    }
}
