using FluentMigrator;

namespace Data.Migrations
{
    [Migration(20230314214159)]
    public class Migration_20230314181859_InitialMigration: Migration
    {
        public override void Up()
        {

            Create.Schema("Tool");

            Create.Table("Degree").InSchema("Tool")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("DateCreated").AsDateTime2().NotNullable();

            Create.Table("CV").InSchema("Tool")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Identifier").AsInt32().Identity()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Mobile").AsString().Nullable()
                .WithColumn("DegreeId").AsGuid().Nullable().ForeignKey(
                    foreignKeyName: $"FK_CV_DegreeId",
                    primaryTableSchema: "Tool",
                    primaryTableName: "Degree",
                    primaryColumnName: "Id"
                )
                .WithColumn("Blob").AsString(int.MaxValue).Nullable()
                .WithColumn("DateCreated").AsDateTime2().NotNullable();


            Execute.Sql(@"
                insert into [Tool].[Degree] values(NEWID(), 'Bsc', getutcdate())
                insert into [Tool].[Degree] values(NEWID(), 'Msc', getutcdate())
                insert into [Tool].[Degree] values(NEWID(), 'PhD', getutcdate())

                CREATE INDEX IX_CV_DegreeId
                ON Tool.CV (DegreeId);
            ");
        }

        public override void Down()
        {
            Delete.Table("CV");
            Delete.Table("Degree");

        }
    }
}
