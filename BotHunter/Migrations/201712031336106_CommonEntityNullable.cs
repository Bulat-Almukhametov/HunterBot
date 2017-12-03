namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommonEntityNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dialogs", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Dialogs", "ChangedOn", c => c.DateTime());
            AlterColumn("dbo.Personalities", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Personalities", "ChangedOn", c => c.DateTime());
            AlterColumn("dbo.Skills", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Skills", "ChangedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "ChangedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Skills", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Personalities", "ChangedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Personalities", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dialogs", "ChangedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dialogs", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
