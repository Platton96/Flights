namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredFlights",
                c => new
                    {
                        RegisteredFlightId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        UserId = c.String(),
                        Status = c.Int(nullable: false),
                        DataOfBooking = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RegisteredFlightId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisteredFlights", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RegisteredFlights", new[] { "ApplicationUser_Id" });
            DropTable("dbo.RegisteredFlights");
        }
    }
}
