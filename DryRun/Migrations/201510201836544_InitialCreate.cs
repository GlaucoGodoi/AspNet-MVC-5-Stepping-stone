namespace DryRun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EMail = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        CreationDate = c.DateTime(nullable: false),
                        Text = c.String(nullable: false, maxLength: 500),
                        Answer = c.String(maxLength: 1000),
                        MessageType = c.Int(nullable: false),
                        BusinessArea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactMessages");
        }
    }
}
