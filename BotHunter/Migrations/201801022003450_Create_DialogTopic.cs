namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DialogTopic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DialogTopics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Guid(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DialogTopics", t => t.ParentId)
                .Index(t => t.ParentId);
            
            AddColumn("dbo.Dialogs", "TopicId", c => c.Guid());
            CreateIndex("dbo.Dialogs", "TopicId");
            AddForeignKey("dbo.Dialogs", "TopicId", "dbo.DialogTopics", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dialogs", "TopicId", "dbo.DialogTopics");
            DropForeignKey("dbo.DialogTopics", "ParentId", "dbo.DialogTopics");
            DropIndex("dbo.DialogTopics", new[] { "ParentId" });
            DropIndex("dbo.Dialogs", new[] { "TopicId" });
            DropColumn("dbo.Dialogs", "TopicId");
            DropTable("dbo.DialogTopics");
        }
    }
}
