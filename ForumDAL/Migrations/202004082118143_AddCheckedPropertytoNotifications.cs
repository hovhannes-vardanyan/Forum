namespace ForumDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckedPropertytoNotifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Checked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Checked");
        }
    }
}
