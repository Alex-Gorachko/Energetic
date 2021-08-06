namespace Energetic.SqlEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHistory_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turnaments", "History_Id", "dbo.Histories");
            DropIndex("dbo.Turnaments", new[] { "History_Id" });
            AddColumn("dbo.Turnaments", "History_Id1", c => c.Int());
            AlterColumn("dbo.Turnaments", "History_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Turnaments", "History_Id1");
            AddForeignKey("dbo.Turnaments", "History_Id1", "dbo.Histories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turnaments", "History_Id1", "dbo.Histories");
            DropIndex("dbo.Turnaments", new[] { "History_Id1" });
            AlterColumn("dbo.Turnaments", "History_Id", c => c.Int());
            DropColumn("dbo.Turnaments", "History_Id1");
            CreateIndex("dbo.Turnaments", "History_Id");
            AddForeignKey("dbo.Turnaments", "History_Id", "dbo.Histories", "Id");
        }
    }
}
