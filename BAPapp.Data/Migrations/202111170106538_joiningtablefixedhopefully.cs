namespace BAPapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joiningtablefixedhopefully : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EvenCreate", newName: "Event");
            DropForeignKey("dbo.VenueCrewer", "Venue_VenueId", "dbo.Venue");
            DropForeignKey("dbo.VenueCrewer", "Crewer_CrewerId", "dbo.Crewer");
            DropIndex("dbo.VenueCrewer", new[] { "Venue_VenueId" });
            DropIndex("dbo.VenueCrewer", new[] { "Crewer_CrewerId" });
            CreateTable(
                "dbo.VenueCrewer",
                c => new
                    {
                        VenueCrewerId = c.Int(nullable: false, identity: true),
                        VenueId = c.String(maxLength: 128),
                        CrewerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VenueCrewerId)
                .ForeignKey("dbo.Crewer", t => t.CrewerId)
                .ForeignKey("dbo.Venue", t => t.VenueId)
                .Index(t => t.VenueId)
                .Index(t => t.CrewerId);
            
            AddColumn("dbo.Crewer", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Event", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Venue", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Venue", "Crewer_CrewerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Venue", "Crewer_CrewerId");
            AddForeignKey("dbo.Venue", "Crewer_CrewerId", "dbo.Crewer", "CrewerId");
            DropTable("dbo.VenueCrewer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VenueCrewer",
                c => new
                    {
                        Venue_VenueId = c.String(nullable: false, maxLength: 128),
                        Crewer_CrewerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Venue_VenueId, t.Crewer_CrewerId });
            
            DropForeignKey("dbo.Venue", "Crewer_CrewerId", "dbo.Crewer");
            DropForeignKey("dbo.VenueCrewer", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.VenueCrewer", "CrewerId", "dbo.Crewer");
            DropIndex("dbo.VenueCrewer", new[] { "CrewerId" });
            DropIndex("dbo.VenueCrewer", new[] { "VenueId" });
            DropIndex("dbo.Venue", new[] { "Crewer_CrewerId" });
            DropColumn("dbo.Venue", "Crewer_CrewerId");
            DropColumn("dbo.Venue", "OwnerId");
            DropColumn("dbo.Event", "OwnerId");
            DropColumn("dbo.Crewer", "OwnerId");
            DropTable("dbo.VenueCrewer");
            CreateIndex("dbo.VenueCrewer", "Crewer_CrewerId");
            CreateIndex("dbo.VenueCrewer", "Venue_VenueId");
            AddForeignKey("dbo.VenueCrewer", "Crewer_CrewerId", "dbo.Crewer", "CrewerId", cascadeDelete: true);
            AddForeignKey("dbo.VenueCrewer", "Venue_VenueId", "dbo.Venue", "VenueId", cascadeDelete: true);
            RenameTable(name: "dbo.Event", newName: "EvenCreate");
        }
    }
}
