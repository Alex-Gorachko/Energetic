namespace Energetic.SqlEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turnaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Place = c.Int(nullable: false),
                        Points = c.String(),
                        Balls = c.String(),
                        History_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Histories", t => t.History_Id)
                .Index(t => t.History_Id);
            
            CreateTable(
                "dbo.MainPhotoUsualInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Type = c.Int(nullable: false),
                        Surname = c.String(),
                        Name = c.String(),
                        Fathersname = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                        Fathersname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Position = c.String(),
                        Goals = c.Int(nullable: false),
                        Playes = c.Int(nullable: false),
                        YellowCard = c.Int(nullable: false),
                        RedCard = c.Int(nullable: false),
                        MainSquade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Name = c.String(),
                        Place = c.String(),
                        People = c.Int(nullable: false),
                        Syte = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Game = c.Int(nullable: false),
                        Win = c.Int(nullable: false),
                        Drow = c.Int(nullable: false),
                        Loose = c.Int(nullable: false),
                        Goals = c.String(),
                        Points = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        Forward = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turnaments", "History_Id", "dbo.Histories");
            DropIndex("dbo.Turnaments", new[] { "History_Id" });
            DropColumn("dbo.Contacts", "Type");
            DropTable("dbo.Videos");
            DropTable("dbo.Teams");
            DropTable("dbo.Stadia");
            DropTable("dbo.Players");
            DropTable("dbo.Personals");
            DropTable("dbo.MainPhotoUsualInformations");
            DropTable("dbo.Turnaments");
            DropTable("dbo.Histories");
            DropTable("dbo.Cubs");
            DropTable("dbo.Albums");
        }
    }
}
