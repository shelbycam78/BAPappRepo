namespace BAPapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControllerChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "VenueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "VenueId");
            AddForeignKey("dbo.Event", "VenueId", "dbo.Venue", "VenueId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "VenueId", "dbo.Venue");
            DropIndex("dbo.Event", new[] { "VenueId" });
            DropColumn("dbo.Event", "VenueId");
        }
    }
}
