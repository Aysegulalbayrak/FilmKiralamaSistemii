namespace FilmKiralamaSistm.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabloguncelle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMusteri", "MusteriDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblMusteri", "MusteriDurumu");
        }
    }
}
