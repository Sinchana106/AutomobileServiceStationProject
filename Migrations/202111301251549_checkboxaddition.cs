namespace AutomobileServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkboxaddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSubTypes", "check", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceSubTypes", "check");
        }
    }
}
