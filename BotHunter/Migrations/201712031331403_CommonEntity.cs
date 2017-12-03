namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommonEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dialogs", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Dialogs", "ChangedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Dialogs", "LastEditor_Id", c => c.Guid());
            AddColumn("dbo.Personalities", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Personalities", "ChangedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Personalities", "Creator_Id", c => c.Guid());
            AddColumn("dbo.Personalities", "LastEditor_Id", c => c.Guid());
            AddColumn("dbo.Skills", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Skills", "ChangedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Skills", "Creator_Id", c => c.Guid());
            AddColumn("dbo.Skills", "LastEditor_Id", c => c.Guid());
            CreateIndex("dbo.Dialogs", "LastEditor_Id");
            CreateIndex("dbo.Personalities", "Creator_Id");
            CreateIndex("dbo.Personalities", "LastEditor_Id");
            CreateIndex("dbo.Skills", "Creator_Id");
            CreateIndex("dbo.Skills", "LastEditor_Id");
            AddForeignKey("dbo.Dialogs", "LastEditor_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Personalities", "Creator_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Personalities", "LastEditor_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Skills", "Creator_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Skills", "LastEditor_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "LastEditor_Id", "dbo.Users");
            DropForeignKey("dbo.Skills", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Personalities", "LastEditor_Id", "dbo.Users");
            DropForeignKey("dbo.Personalities", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Dialogs", "LastEditor_Id", "dbo.Users");
            DropIndex("dbo.Skills", new[] { "LastEditor_Id" });
            DropIndex("dbo.Skills", new[] { "Creator_Id" });
            DropIndex("dbo.Personalities", new[] { "LastEditor_Id" });
            DropIndex("dbo.Personalities", new[] { "Creator_Id" });
            DropIndex("dbo.Dialogs", new[] { "LastEditor_Id" });
            DropColumn("dbo.Skills", "LastEditor_Id");
            DropColumn("dbo.Skills", "Creator_Id");
            DropColumn("dbo.Skills", "ChangedOn");
            DropColumn("dbo.Skills", "CreatedOn");
            DropColumn("dbo.Personalities", "LastEditor_Id");
            DropColumn("dbo.Personalities", "Creator_Id");
            DropColumn("dbo.Personalities", "ChangedOn");
            DropColumn("dbo.Personalities", "CreatedOn");
            DropColumn("dbo.Dialogs", "LastEditor_Id");
            DropColumn("dbo.Dialogs", "ChangedOn");
            DropColumn("dbo.Dialogs", "CreatedOn");
        }
    }
}
