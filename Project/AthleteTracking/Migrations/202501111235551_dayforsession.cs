namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dayforsession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "Day", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "Day");
        }
    }
}
