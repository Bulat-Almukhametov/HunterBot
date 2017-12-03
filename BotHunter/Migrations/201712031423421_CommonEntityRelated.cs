namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommonEntityRelated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dialogs", "User_Id", c => c.Guid());
            AddColumn("dbo.Personalities", "User_Id", c => c.Guid());
            AddColumn("dbo.Skills", "User_Id", c => c.Guid());
            CreateIndex("dbo.Dialogs", "User_Id");
            CreateIndex("dbo.Personalities", "User_Id");
            CreateIndex("dbo.Skills", "User_Id");
            AddForeignKey("dbo.Dialogs", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Personalities", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Skills", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Personalities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Dialogs", "User_Id", "dbo.Users");
            DropIndex("dbo.Skills", new[] { "User_Id" });
            DropIndex("dbo.Personalities", new[] { "User_Id" });
            DropIndex("dbo.Dialogs", new[] { "User_Id" });
            DropColumn("dbo.Skills", "User_Id");
            DropColumn("dbo.Personalities", "User_Id");
            DropColumn("dbo.Dialogs", "User_Id");
        }
    }
}
