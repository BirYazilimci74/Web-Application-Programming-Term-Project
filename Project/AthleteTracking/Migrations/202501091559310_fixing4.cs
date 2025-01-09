namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "BranchId", "dbo.Branches");
            DropIndex("dbo.Admins", new[] { "BranchId" });
            DropColumn("dbo.Admins", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "BranchId");
            AddForeignKey("dbo.Admins", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
