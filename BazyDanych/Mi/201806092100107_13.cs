namespace BazyDanych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Nieruchomosc", newName: "Nieruchomoscs");
            RenameTable(name: "dbo.Osoba", newName: "Osobas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Osobas", newName: "Osoba");
            RenameTable(name: "dbo.Nieruchomoscs", newName: "Nieruchomosc");
        }
    }
}
