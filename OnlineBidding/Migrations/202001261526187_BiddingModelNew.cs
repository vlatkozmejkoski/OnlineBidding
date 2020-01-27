namespace OnlineBidding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BiddingModelNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biddings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        AuctionId = c.Guid(nullable: false),
                        BidPrice = c.Single(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.AuctionId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Biddings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Biddings", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Biddings", new[] { "User_Id" });
            DropIndex("dbo.Biddings", new[] { "AuctionId" });
            DropTable("dbo.Biddings");
        }
    }
}
