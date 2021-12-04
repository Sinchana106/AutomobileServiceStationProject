namespace AutomobileServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatation1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        TransactionId = c.Int(nullable: false),
                        total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        cost = c.Single(),
                        check = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ServiceSubTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        serviceID = c.Int(nullable: false),
                        cost = c.Single(),
                        check = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Services", t => t.serviceID, cascadeDelete: true)
                .Index(t => t.serviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceSubTypes", "serviceID", "dbo.Services");
            DropIndex("dbo.ServiceSubTypes", new[] { "serviceID" });
            DropTable("dbo.ServiceSubTypes");
            DropTable("dbo.Services");
            DropTable("dbo.PaymentInfoes");
            DropTable("dbo.ContactInfoes");
        }
    }
}
