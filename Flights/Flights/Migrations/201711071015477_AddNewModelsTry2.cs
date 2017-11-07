namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModelsTry2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        DepartureSity = c.String(),
                        SityOfEntry = c.String(),
                        DateFlight = c.DateTime(nullable: false),
                        Destance = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateIndex("dbo.RegisteredFlights", "FlightId");
            AddForeignKey("dbo.RegisteredFlights", "FlightId", "dbo.Flights", "FlightId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisteredFlights", "FlightId", "dbo.Flights");
            DropIndex("dbo.RegisteredFlights", new[] { "FlightId" });
            DropTable("dbo.Flights");
        }
    }
}
