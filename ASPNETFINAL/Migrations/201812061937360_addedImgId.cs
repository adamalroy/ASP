namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImgId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "UserId");
        }
    }
}
