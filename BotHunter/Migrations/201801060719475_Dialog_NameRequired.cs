namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dialog_NameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dialogs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dialogs", "Name", c => c.String());
        }
    }
}
