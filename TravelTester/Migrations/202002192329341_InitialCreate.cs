namespace TravelTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Localtion = c.String(),
                        starts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place_Id = c.Int(nullable: false),
                        Transporter_Id = c.Int(nullable: false),
                        Titile = c.String(),
                        Description = c.String(),
                        Quantity_people = c.String(),
                        Price = c.Double(nullable: false),
                        Time_start = c.DateTime(nullable: false),
                        Time_end = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        Time_departure = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.Place_Id, cascadeDelete: true)
                .ForeignKey("dbo.Transporters", t => t.Transporter_Id, cascadeDelete: true)
                .Index(t => t.Place_Id)
                .Index(t => t.Transporter_Id);
            
            CreateTable(
                "dbo.Transporters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "Transporter_Id", "dbo.Transporters");
            DropForeignKey("dbo.Tours", "Place_Id", "dbo.Places");
            DropIndex("dbo.Tours", new[] { "Transporter_Id" });
            DropIndex("dbo.Tours", new[] { "Place_Id" });
            DropTable("dbo.Transporters");
            DropTable("dbo.Tours");
            DropTable("dbo.Places");
        }
    }
}
