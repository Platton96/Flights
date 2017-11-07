namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserIdOnRegFlg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisteredFlights", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RegisteredFlights", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.RegisteredFlights", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.RegisteredFlights", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.RegisteredFlights", "ApplicationUser_Id1");
            AddForeignKey("dbo.RegisteredFlights", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.RegisteredFlights", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisteredFlights", "UserId", c => c.String());
            DropForeignKey("dbo.RegisteredFlights", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.RegisteredFlights", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.RegisteredFlights", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.RegisteredFlights", "ApplicationUser_Id1");
            CreateIndex("dbo.RegisteredFlights", "ApplicationUser_Id");
            AddForeignKey("dbo.RegisteredFlights", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
