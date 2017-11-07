namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RegisteredFlights", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.RegisteredFlights", "ApplicationUser_Id");
            RenameColumn(table: "dbo.RegisteredFlights", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            AddColumn("dbo.RegisteredFlights", "UserId", c => c.String());
            AlterColumn("dbo.RegisteredFlights", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RegisteredFlights", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegisteredFlights", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.RegisteredFlights", "ApplicationUser_Id", c => c.String());
            DropColumn("dbo.RegisteredFlights", "UserId");
            RenameColumn(table: "dbo.RegisteredFlights", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            AddColumn("dbo.RegisteredFlights", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.RegisteredFlights", "ApplicationUser_Id1");
        }
    }
}
