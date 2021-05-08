namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameAccomodationPackage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccodomationPackages", newName: "AccomodationPackages");
            DropForeignKey("dbo.Accomodations", "AccodomationPackage_ID", "dbo.AccodomationPackages");
            DropIndex("dbo.Accomodations", new[] { "AccodomationPackage_ID" });
            DropColumn("dbo.Accomodations", "AccomodationPackageID");
            RenameColumn(table: "dbo.Accomodations", name: "AccodomationPackage_ID", newName: "AccomodationPackageID");
            AlterColumn("dbo.Accomodations", "AccomodationPackageID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accomodations", "AccomodationPackageID");
            AddForeignKey("dbo.Accomodations", "AccomodationPackageID", "dbo.AccomodationPackages", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accomodations", "AccomodationPackageID", "dbo.AccomodationPackages");
            DropIndex("dbo.Accomodations", new[] { "AccomodationPackageID" });
            AlterColumn("dbo.Accomodations", "AccomodationPackageID", c => c.Int());
            RenameColumn(table: "dbo.Accomodations", name: "AccomodationPackageID", newName: "AccodomationPackage_ID");
            AddColumn("dbo.Accomodations", "AccomodationPackageID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accomodations", "AccodomationPackage_ID");
            AddForeignKey("dbo.Accomodations", "AccodomationPackage_ID", "dbo.AccodomationPackages", "ID");
            RenameTable(name: "dbo.AccomodationPackages", newName: "AccodomationPackages");
        }
    }
}
