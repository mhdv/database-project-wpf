namespace BazyDanych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nieruchomosc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adres = c.String(),
                        Powierzchnia = c.Single(nullable: false),
                        Typ = c.String(),
                        PracownikID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Spotkanie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cel = c.String(),
                        Termin = c.String(),
                        Miejsce = c.String(),
                        PracownikID = c.Int(nullable: false),
                        KlientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Biuro",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        TypBiura = c.String(),
                        Stanowiska = c.Int(nullable: false),
                        Parking = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nieruchomosc", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Dom",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        TypDomu = c.String(),
                        Pokoje = c.Int(nullable: false),
                        Garaz = c.String(),
                        PowierzchniaZabudowy = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nieruchomosc", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Grunt",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        TypGruntu = c.String(),
                        Przeznaczenie = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nieruchomosc", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Hala",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        TypHali = c.String(),
                        Wysokosc = c.Single(nullable: false),
                        Media = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nieruchomosc", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Mieszkanie",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Pokoje = c.Int(nullable: false),
                        Pietro = c.Int(nullable: false),
                        Garaz = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nieruchomosc", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Umowa",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Typ = c.String(),
                        Prowizja = c.Single(nullable: false),
                        NieruchomoscID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Spotkanie", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Umowa", "ID", "dbo.Spotkanie");
            DropForeignKey("dbo.Mieszkanie", "ID", "dbo.Nieruchomosc");
            DropForeignKey("dbo.Hala", "ID", "dbo.Nieruchomosc");
            DropForeignKey("dbo.Grunt", "ID", "dbo.Nieruchomosc");
            DropForeignKey("dbo.Dom", "ID", "dbo.Nieruchomosc");
            DropForeignKey("dbo.Biuro", "ID", "dbo.Nieruchomosc");
            DropIndex("dbo.Umowa", new[] { "ID" });
            DropIndex("dbo.Mieszkanie", new[] { "ID" });
            DropIndex("dbo.Hala", new[] { "ID" });
            DropIndex("dbo.Grunt", new[] { "ID" });
            DropIndex("dbo.Dom", new[] { "ID" });
            DropIndex("dbo.Biuro", new[] { "ID" });
            DropTable("dbo.Umowa");
            DropTable("dbo.Mieszkanie");
            DropTable("dbo.Hala");
            DropTable("dbo.Grunt");
            DropTable("dbo.Dom");
            DropTable("dbo.Biuro");
            DropTable("dbo.Spotkanie");
            DropTable("dbo.Nieruchomosc");
        }
    }
}
