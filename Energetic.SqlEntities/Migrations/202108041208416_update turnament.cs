namespace Energetic.SqlEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateturnament : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turnaments", "History_Id1", "dbo.Histories");
            DropIndex("dbo.Turnaments", new[] { "History_Id1" });
            DropColumn("dbo.Turnaments", "History_Id");
            DropColumn("dbo.Turnaments", "History_Id1");
            DropTable("dbo.Histories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Turnaments", "History_Id1", c => c.Int());
            AddColumn("dbo.Turnaments", "History_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Turnaments", "History_Id1");
            AddForeignKey("dbo.Turnaments", "History_Id1", "dbo.Histories", "Id");
        }
    }
}
