namespace AutomobileServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkbox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "check", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceSubTypes", "cost");
            DropColumn("dbo.Services", "check");
        }
    }
}
