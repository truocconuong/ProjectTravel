namespace TravelTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202002210552114_update_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Content", c => c.String());
            AddColumn("dbo.Places", "Images", c => c.String());
            AddColumn("dbo.Tours", "Content", c => c.String());
            AddColumn("dbo.Tours", "Images", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "Images");
            DropColumn("dbo.Tours", "Content");
            DropColumn("dbo.Places", "Images");
            DropColumn("dbo.Places", "Content");
        }
    }
}
