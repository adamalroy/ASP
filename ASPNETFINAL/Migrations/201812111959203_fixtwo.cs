namespace ASPNETFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixtwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserNameValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserNameValue");
        }
    }
}
