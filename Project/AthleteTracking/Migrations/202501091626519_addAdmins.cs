namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Admins", "BranchId", "dbo.Branches");
            DropIndex("dbo.Admins", new[] { "BranchId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.Admins");
        }
    }
}
