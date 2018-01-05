namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeToTopic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DialogTopics", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DialogTopics", "Type");
        }
    }
}
