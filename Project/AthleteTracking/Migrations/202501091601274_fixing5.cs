namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "BranchId");
            AddForeignKey("dbo.Admins", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "BranchId", "dbo.Branches");
            DropIndex("dbo.Admins", new[] { "BranchId" });
            DropColumn("dbo.Admins", "BranchId");
        }
    }
}
