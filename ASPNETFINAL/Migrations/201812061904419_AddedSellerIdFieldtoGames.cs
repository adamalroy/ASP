namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSellerIdFieldtoGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "SellerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "SellerId");
        }
    }
}
