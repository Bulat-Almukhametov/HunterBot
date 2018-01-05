namespace BotHunter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_TopicTypeToEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DialogTopics", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DialogTopics", "Type", c => c.String());
        }
    }
}
