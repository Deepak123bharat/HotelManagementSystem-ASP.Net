namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccodomationPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccodomationID = c.Int(nullable: false),
                        Name = c.String(),
                        NoOfRoom = c.Int(nullable: false),
                        FeePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccomodationType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccomodationTypes", t => t.AccomodationType_ID)
                .Index(t => t.AccomodationType_ID);
            
            CreateTable(
                "dbo.AccomodationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accodomations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationPackageID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        AccodomationPackage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccodomationPackages", t => t.AccodomationPackage_ID)
                .Index(t => t.AccodomationPackage_ID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationID = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Accodomation_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accodomations", t => t.Accodomation_ID)
                .Index(t => t.Accodomation_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Accodomation_ID", "dbo.Accodomations");
            DropForeignKey("dbo.Accodomations", "AccodomationPackage_ID", "dbo.AccodomationPackages");
            DropForeignKey("dbo.AccodomationPackages", "AccomodationType_ID", "dbo.AccomodationTypes");
            DropIndex("dbo.Bookings", new[] { "Accodomation_ID" });
            DropIndex("dbo.Accodomations", new[] { "AccodomationPackage_ID" });
            DropIndex("dbo.AccodomationPackages", new[] { "AccomodationType_ID" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Accodomations");
            DropTable("dbo.AccomodationTypes");
            DropTable("dbo.AccodomationPackages");
        }
    }
}
