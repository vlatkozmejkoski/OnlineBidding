namespace OnlineBidding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updtedauctionmode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "ImagePath");
        }
    }
}
