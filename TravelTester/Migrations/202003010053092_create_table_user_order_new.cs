namespace TravelTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_user_order_new : DbMigration
    {
        public override void Up()
        {

            CreateTable(
              "dbo.Users",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  FirstName = c.String(),
                  LastName = c.String(),
                  Email = c.String(),
                  Address = c.String(),
                  City = c.String(),
                  State = c.String(),
                  PostCode = c.Int(nullable: false),
                  CardName = c.String(),
                  CardNumber = c.Int(nullable: false),
                  SecurityCode = c.String(),
                  ExpiraDateMonth = c.String(),
                  ExpiraDateYear = c.String(),
                  CreatedAt = c.DateTime(nullable: false),
              })
              .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Tours_Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.Tours_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Tours_Id);
        }
    }
}
