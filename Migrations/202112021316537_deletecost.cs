namespace AutomobileServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "cost", c => c.Single());
        }
    }
}
