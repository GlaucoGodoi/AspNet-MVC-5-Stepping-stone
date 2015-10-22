namespace DryRun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnswerDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessages", "AnswerDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactMessages", "AnswerDate");
        }
    }
}
