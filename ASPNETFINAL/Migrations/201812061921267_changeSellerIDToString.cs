namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSellerIDToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Game", "SellerId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Game", "SellerId", c => c.Int(nullable: false));
        }
    }
}
