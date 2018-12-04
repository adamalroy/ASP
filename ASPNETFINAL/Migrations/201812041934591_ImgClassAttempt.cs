namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImgClassAttempt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Image",
               c => new
               {
                   ImgId = c.Int(nullable: false, identity: true),
                   ImgURL = c.Int(nullable: false),
                })
               .PrimaryKey(t => t.ImgId);
        }
        
        public override void Down()
        {
        }
    }
}
