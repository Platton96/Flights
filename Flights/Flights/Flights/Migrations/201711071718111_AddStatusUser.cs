namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "statusUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "statusUser");
        }
    }
}
