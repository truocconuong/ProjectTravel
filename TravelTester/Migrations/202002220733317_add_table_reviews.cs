namespace TravelTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_reviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tour_Id = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Content = c.String(),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.Tour_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.Reviews", new[] { "Tour_Id" });
            DropTable("dbo.Reviews");
        }
    }
}
