namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingCartToWorkWithController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cart", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Cart", "DateCreated");
        }
    }
}
