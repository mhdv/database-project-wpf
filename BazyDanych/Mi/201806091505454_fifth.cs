namespace BazyDanych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pracownik", "OsobaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pracownik", "OsobaId", c => c.Int(nullable: false));
        }
    }
}
