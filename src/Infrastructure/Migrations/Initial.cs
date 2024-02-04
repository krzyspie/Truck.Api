using FluentMigrator;

namespace Infrastructure.Migrations
{
    [Migration(202402011818)]
    public class Initial : Migration
    {
        private readonly string tableName = "Trucks";
        public override void Down()
        {
            Delete.Table(tableName);
        }

        public override void Up()
        {
            Create.Table(tableName)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Code").AsString(7).Unique()
                .WithColumn("Name").AsString(20)
                .WithColumn("Status").AsString(20)
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("DateCreated").AsDateTime()
                .WithColumn("DateModified").AsDateTime().Nullable();
        }
    }
}
