namespace ForumDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotifactionCommentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "CommentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "CommentID");
        }
    }
}
