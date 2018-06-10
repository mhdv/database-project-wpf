namespace BazyDanych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pracownik = c.String(),
                        Sprzedane = c.Int(nullable: false),
                        Kupione = c.Int(nullable: false),
                        Preferencje = c.String(),
                        OsobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Osobas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Telefon = c.String(),
                        Adres = c.String(),
                        Mail = c.String(),
                        IloscTransakcji = c.Int(nullable: false),
                        Typ = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pracowniks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Stanowisko = c.String(),
                        Dostepnosc = c.String(),
                        Wynagrodzenie = c.Single(nullable: false),
                        DniUrlopu = c.Int(nullable: false),
                        OsobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pracowniks");
            DropTable("dbo.Osobas");
            DropTable("dbo.Klients");
        }
    }
}
