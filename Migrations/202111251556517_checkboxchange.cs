namespace AutomobileServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkboxchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "cost", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "cost", c => c.String());
        }
    }
}
