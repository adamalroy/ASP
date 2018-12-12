namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgId2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "ImgId", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "ImgId");
        }
    }
}
