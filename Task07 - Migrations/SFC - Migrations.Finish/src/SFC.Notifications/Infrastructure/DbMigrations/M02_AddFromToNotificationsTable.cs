using FluentMigrator;

namespace SFC.Notifications.Infrastructure.DbMigrations
{
  [Migration(202309212229)]
  public class M02_AddFromToNotificationsTable : Migration
  {
    public override void Up()
    {
      Alter.Table("Notifications")
        .InSchema("Notifications")
        .AddColumn("FromEmail").AsString().Nullable();
    }

    public override void Down()
    {
      Delete.Column("FromEmail").FromTable("Notifications").InSchema("Notifications");      
    }
  }
}
