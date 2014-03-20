namespace AForgeHack.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        CameraID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Facility_FacilityID = c.Int(),
                    })
                .PrimaryKey(t => t.CameraID)
                .ForeignKey("dbo.Facilities", t => t.Facility_FacilityID)
                .Index(t => t.Facility_FacilityID);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        FacilityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FacilityID);
            
            CreateTable(
                "dbo.WatchPoints",
                c => new
                    {
                        WatchPointID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Top = c.Int(nullable: false),
                        Left = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Camera_CameraID = c.Int(),
                    })
                .PrimaryKey(t => t.WatchPointID)
                .ForeignKey("dbo.Cameras", t => t.Camera_CameraID)
                .Index(t => t.Camera_CameraID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        Notes = c.String(),
                        WatchPoint_WatchPointID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.WatchPoints", t => t.WatchPoint_WatchPointID)
                .Index(t => t.WatchPoint_WatchPointID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "WatchPoint_WatchPointID", "dbo.WatchPoints");
            DropForeignKey("dbo.WatchPoints", "Camera_CameraID", "dbo.Cameras");
            DropForeignKey("dbo.Cameras", "Facility_FacilityID", "dbo.Facilities");
            DropIndex("dbo.Events", new[] { "WatchPoint_WatchPointID" });
            DropIndex("dbo.WatchPoints", new[] { "Camera_CameraID" });
            DropIndex("dbo.Cameras", new[] { "Facility_FacilityID" });
            DropTable("dbo.Events");
            DropTable("dbo.WatchPoints");
            DropTable("dbo.Facilities");
            DropTable("dbo.Cameras");
        }
    }
}
