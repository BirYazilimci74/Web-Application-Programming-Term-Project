namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Admins", new[] { "Branch_Id" });
            DropColumn("dbo.Admins", "BrachId");
            DropColumn("dbo.Admins", "Branch_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Branch_Id", c => c.Int());
            AddColumn("dbo.Admins", "BrachId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "Branch_Id");
            AddForeignKey("dbo.Admins", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}
