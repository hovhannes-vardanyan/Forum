namespace ForumDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post_Id = c.Int(nullable: false),
                        Message = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                        UserLogin = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.SubTopics", "MainTopic_MainTopicId", "dbo.MainTopics");
            DropForeignKey("dbo.Posts", "SubtopicID", "dbo.SubTopics");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.SubTopics", new[] { "MainTopic_MainTopicId" });
            DropIndex("dbo.Posts", new[] { "SubtopicID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.Users");
            DropTable("dbo.MainTopics");
            DropTable("dbo.SubTopics");
            DropTable("dbo.Posts");
            DropTable("dbo.Notifications");
            DropTable("dbo.Comments");
        }
    }
}
