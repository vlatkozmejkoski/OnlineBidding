namespace OnlineBidding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "Category");
        }
    }
}
