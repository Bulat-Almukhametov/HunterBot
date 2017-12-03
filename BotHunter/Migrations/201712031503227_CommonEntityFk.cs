namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommonEntityFk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dialogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Personalities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Skills", "User_Id", "dbo.Users");
            DropIndex("dbo.Dialogs", new[] { "User_Id" });
            DropIndex("dbo.Personalities", new[] { "User_Id" });
            DropIndex("dbo.Skills", new[] { "User_Id" });
            RenameColumn(table: "dbo.Dialogs", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.Dialogs", name: "LastEditor_Id", newName: "LastEditorId");
            RenameColumn(table: "dbo.Personalities", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.Personalities", name: "LastEditor_Id", newName: "LastEditorId");
            RenameColumn(table: "dbo.Skills", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.Skills", name: "LastEditor_Id", newName: "LastEditorId");
            RenameIndex(table: "dbo.Dialogs", name: "IX_Creator_Id", newName: "IX_CreatorId");
            RenameIndex(table: "dbo.Dialogs", name: "IX_LastEditor_Id", newName: "IX_LastEditorId");
            RenameIndex(table: "dbo.Personalities", name: "IX_Creator_Id", newName: "IX_CreatorId");
            RenameIndex(table: "dbo.Personalities", name: "IX_LastEditor_Id", newName: "IX_LastEditorId");
            RenameIndex(table: "dbo.Skills", name: "IX_Creator_Id", newName: "IX_CreatorId");
            RenameIndex(table: "dbo.Skills", name: "IX_LastEditor_Id", newName: "IX_LastEditorId");
            DropColumn("dbo.Dialogs", "User_Id");
            DropColumn("dbo.Personalities", "User_Id");
            DropColumn("dbo.Skills", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "User_Id", c => c.Guid());
            AddColumn("dbo.Personalities", "User_Id", c => c.Guid());
            AddColumn("dbo.Dialogs", "User_Id", c => c.Guid());
            RenameIndex(table: "dbo.Skills", name: "IX_LastEditorId", newName: "IX_LastEditor_Id");
            RenameIndex(table: "dbo.Skills", name: "IX_CreatorId", newName: "IX_Creator_Id");
            RenameIndex(table: "dbo.Personalities", name: "IX_LastEditorId", newName: "IX_LastEditor_Id");
            RenameIndex(table: "dbo.Personalities", name: "IX_CreatorId", newName: "IX_Creator_Id");
            RenameIndex(table: "dbo.Dialogs", name: "IX_LastEditorId", newName: "IX_LastEditor_Id");
            RenameIndex(table: "dbo.Dialogs", name: "IX_CreatorId", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Skills", name: "LastEditorId", newName: "LastEditor_Id");
            RenameColumn(table: "dbo.Skills", name: "CreatorId", newName: "Creator_Id");
            RenameColumn(table: "dbo.Personalities", name: "LastEditorId", newName: "LastEditor_Id");
            RenameColumn(table: "dbo.Personalities", name: "CreatorId", newName: "Creator_Id");
            RenameColumn(table: "dbo.Dialogs", name: "LastEditorId", newName: "LastEditor_Id");
            RenameColumn(table: "dbo.Dialogs", name: "CreatorId", newName: "Creator_Id");
            CreateIndex("dbo.Skills", "User_Id");
            CreateIndex("dbo.Personalities", "User_Id");
            CreateIndex("dbo.Dialogs", "User_Id");
            AddForeignKey("dbo.Skills", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Personalities", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Dialogs", "User_Id", "dbo.Users", "Id");
        }
    }
}
