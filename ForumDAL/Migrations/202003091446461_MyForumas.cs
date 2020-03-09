namespace ForumDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyForumas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications");
            DropIndex("dbo.Users", new[] { "Notification_Id" });
            AddColumn("dbo.Notifications", "User_UserId", c => c.Int());
            CreateIndex("dbo.Notifications", "User_UserId");
            AddForeignKey("dbo.Notifications", "User_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.Users", "Notification_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Notification_Id", c => c.Int());
            DropForeignKey("dbo.Notifications", "User_UserId", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "User_UserId" });
            DropColumn("dbo.Notifications", "User_UserId");
            CreateIndex("dbo.Users", "Notification_Id");
            AddForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications", "Id");
        }
    }
}
