namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follwings",
                c => new
                    {
                        FollowrId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        Follower_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowrId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Follower_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FolloweeId)
                .Index(t => t.Follower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follwings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follwings", "Follower_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follwings", new[] { "Follower_Id" });
            DropIndex("dbo.Follwings", new[] { "FolloweeId" });
            DropTable("dbo.Follwings");
        }
    }
}
