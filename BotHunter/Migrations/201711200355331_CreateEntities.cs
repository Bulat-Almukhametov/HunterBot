namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dialogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        BlocksXml = c.String(),
                        Aiml = c.String(),
                        Creator_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personalities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telegram = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Personality_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personalities", t => t.Personality_Id)
                .Index(t => t.Personality_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Personality_Id", "dbo.Personalities");
            DropForeignKey("dbo.Dialogs", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Skills", new[] { "Personality_Id" });
            DropIndex("dbo.Dialogs", new[] { "Creator_Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.Personalities");
            DropTable("dbo.Users");
            DropTable("dbo.Dialogs");
        }
    }
}
