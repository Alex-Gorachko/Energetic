namespace Energetic.SqlEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class turnamen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turnaments", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Turnaments", "Year");
        }
    }
}
