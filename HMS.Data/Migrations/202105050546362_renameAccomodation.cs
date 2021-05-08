namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameAccomodation : DbMigration
    {
        public override void Up()
        {
            
            DropForeignKey("dbo.Bookings", "Accodomation_ID", "dbo.Accodomations");
            DropIndex("dbo.Bookings", new[] { "Accodomation_ID" });
            DropColumn("dbo.Bookings", "AccomodationID");
            RenameColumn(table: "dbo.Bookings", name: "Accodomation_ID", newName: "AccomodationID");
            RenameTable(name: "dbo.Accodomations", newName: "Accomodations");
            AlterColumn("dbo.Bookings", "AccomodationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "AccomodationID");
            AddForeignKey("dbo.Bookings", "AccomodationID", "dbo.Accomodations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "AccomodationID", "dbo.Accomodations");
            DropIndex("dbo.Bookings", new[] { "AccomodationID" });
            AlterColumn("dbo.Bookings", "AccomodationID", c => c.Int());
            RenameColumn(table: "dbo.Bookings", name: "AccomodationID", newName: "Accodomation_ID");
            AddColumn("dbo.Bookings", "AccomodationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "Accodomation_ID");
            AddForeignKey("dbo.Bookings", "Accodomation_ID", "dbo.Accodomations", "ID");
            RenameTable(name: "dbo.Accomodations", newName: "Accodomations");
        }
    }
}
