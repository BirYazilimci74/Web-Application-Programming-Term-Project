namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timespan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sessions", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Sessions", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sessions", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sessions", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
