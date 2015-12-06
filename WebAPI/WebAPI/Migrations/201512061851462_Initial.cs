namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AzureServices",
                c => new
                    {
                        AzureServiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AzureServiceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AzureServices");
        }
    }
}
