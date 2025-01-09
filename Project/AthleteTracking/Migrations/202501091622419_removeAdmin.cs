namespace AthleteTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAdmin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "BranchId" });
            DropTable("dbo.Admins");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Admins", "BranchId");
            CreateIndex("dbo.Admins", "UserId");
            AddForeignKey("dbo.Admins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
