namespace AutomobileServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceSubTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        serviceID = c.Int(nullable: false),
                        desc = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Services", t => t.serviceID, cascadeDelete: true)
                .Index(t => t.serviceID);
            
            AddColumn("dbo.Services", "desc", c => c.String());
            AddColumn("dbo.Services", "cost", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceSubTypes", "serviceID", "dbo.Services");
            DropIndex("dbo.ServiceSubTypes", new[] { "serviceID" });
            DropColumn("dbo.Services", "cost");
            DropColumn("dbo.Services", "desc");
            DropTable("dbo.ServiceSubTypes");
        }
    }
}
