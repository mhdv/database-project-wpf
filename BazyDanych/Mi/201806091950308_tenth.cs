namespace BazyDanych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Klient", "Sprzedane", c => c.Int());
            AlterColumn("dbo.Klient", "Kupione", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Klient", "Kupione", c => c.Int(nullable: false));
            AlterColumn("dbo.Klient", "Sprzedane", c => c.Int(nullable: false));
        }
    }
}
