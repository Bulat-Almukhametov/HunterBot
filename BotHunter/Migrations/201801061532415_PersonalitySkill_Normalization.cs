namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalitySkill_Normalization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Personality_Id", "dbo.Personalities");
            DropIndex("dbo.Skills", new[] { "Personality_Id" });
            DropPrimaryKey("dbo.Dialogs");
            DropPrimaryKey("dbo.Personalities");
            DropPrimaryKey("dbo.Skills");
            AlterColumn("dbo.Dialogs", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Personalities", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Skills", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Dialogs", "Id");
            AddPrimaryKey("dbo.Personalities", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            DropColumn("dbo.Skills", "Personality_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Personality_Id", c => c.Guid());
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.Personalities");
            DropPrimaryKey("dbo.Dialogs");
            AlterColumn("dbo.Skills", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Personalities", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Dialogs", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.Personalities", "Id");
            AddPrimaryKey("dbo.Dialogs", "Id");
            CreateIndex("dbo.Skills", "Personality_Id");
            AddForeignKey("dbo.Skills", "Personality_Id", "dbo.Personalities", "Id");
        }
    }
}
