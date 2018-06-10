namespace BazyDanych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Klients", newName: "Klient");
            RenameTable(name: "dbo.Pracowniks", newName: "Pracownik");
            DropPrimaryKey("dbo.Klient");
            DropPrimaryKey("dbo.Pracownik");
            AlterColumn("dbo.Klient", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pracownik", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Klient", "ID");
            AddPrimaryKey("dbo.Pracownik", "ID");
            CreateIndex("dbo.Klient", "ID");
            CreateIndex("dbo.Pracownik", "ID");
            AddForeignKey("dbo.Klient", "ID", "dbo.Osobas", "ID");
            AddForeignKey("dbo.Pracownik", "ID", "dbo.Osobas", "ID");
            DropColumn("dbo.Klient", "OsobaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Klient", "OsobaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pracownik", "ID", "dbo.Osobas");
            DropForeignKey("dbo.Klient", "ID", "dbo.Osobas");
            DropIndex("dbo.Pracownik", new[] { "ID" });
            DropIndex("dbo.Klient", new[] { "ID" });
            DropPrimaryKey("dbo.Pracownik");
            DropPrimaryKey("dbo.Klient");
            AlterColumn("dbo.Pracownik", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Klient", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pracownik", "ID");
            AddPrimaryKey("dbo.Klient", "ID");
            RenameTable(name: "dbo.Pracownik", newName: "Pracowniks");
            RenameTable(name: "dbo.Klient", newName: "Klients");
        }
    }
}
