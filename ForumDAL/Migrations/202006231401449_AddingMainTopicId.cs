namespace ForumDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMainTopicId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubTopics", "MainTopic_MainTopicId", "dbo.MainTopics");
            DropIndex("dbo.SubTopics", new[] { "MainTopic_MainTopicId" });
            RenameColumn(table: "dbo.SubTopics", name: "MainTopic_MainTopicId", newName: "MainTopicId");
            AlterColumn("dbo.SubTopics", "MainTopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubTopics", "MainTopicId");
            AddForeignKey("dbo.SubTopics", "MainTopicId", "dbo.MainTopics", "MainTopicId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubTopics", "MainTopicId", "dbo.MainTopics");
            DropIndex("dbo.SubTopics", new[] { "MainTopicId" });
            AlterColumn("dbo.SubTopics", "MainTopicId", c => c.Int());
            RenameColumn(table: "dbo.SubTopics", name: "MainTopicId", newName: "MainTopic_MainTopicId");
            CreateIndex("dbo.SubTopics", "MainTopic_MainTopicId");
            AddForeignKey("dbo.SubTopics", "MainTopic_MainTopicId", "dbo.MainTopics", "MainTopicId");
        }
    }
}
