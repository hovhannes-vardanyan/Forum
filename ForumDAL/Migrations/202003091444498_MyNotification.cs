namespace ForumDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PostID = c.Int(nullable: false),
                        Title = c.String(),
                        UserID = c.Int(nullable: false),
                        SubtopicID = c.Int(nullable: false),
                        MaintopicID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        UserID = c.Int(nullable: false),
                        SubtopicID = c.Int(nullable: false),
                        MaintopicID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.SubTopics", t => t.SubtopicID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SubtopicID);
            
            CreateTable(
                "dbo.SubTopics",
                c => new
                    {
                        SubTopicID = c.Int(nullable: false, identity: true),
                        SubtopicName = c.String(),
                        MainTopic_MainTopicId = c.Int(),
                    })
                .PrimaryKey(t => t.SubTopicID)
                .ForeignKey("dbo.MainTopics", t => t.MainTopic_MainTopicId)
                .Index(t => t.MainTopic_MainTopicId);
            
            CreateTable(
                "dbo.MainTopics",
                c => new
                    {
                        MainTopicId = c.Int(nullable: false, identity: true),
                        TopicName = c.String(),
                    })
                .PrimaryKey(t => t.MainTopicId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserSurname = c.String(),
                        UserLogin = c.String(),
                        UserPassword = c.String(),
                        Notification_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Notifications", t => t.Notification_Id)
                .Index(t => t.Notification_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post_Id = c.Int(nullable: false),
                        Message = c.String(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications");
            DropForeignKey("dbo.SubTopics", "MainTopic_MainTopicId", "dbo.MainTopics");
            DropForeignKey("dbo.Posts", "SubtopicID", "dbo.SubTopics");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Users", new[] { "Notification_Id" });
            DropIndex("dbo.SubTopics", new[] { "MainTopic_MainTopicId" });
            DropIndex("dbo.Posts", new[] { "SubtopicID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.MainTopics");
            DropTable("dbo.SubTopics");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
