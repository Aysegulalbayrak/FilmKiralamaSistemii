namespace FilmKiralamaSistm.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblYetki",
                c => new
                    {
                        YetkiId = c.Int(nullable: false, identity: true),
                        YetkiAdi = c.String(maxLength: 100, unicode: false),
                        YetkiAciklama = c.String(maxLength: 500, unicode: false),
                        YetkiDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YetkiId);
            
            CreateTable(
                "dbo.tblPersonel",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAdi = c.String(maxLength: 100, unicode: false),
                        PersonelSoyadi = c.String(maxLength: 100, unicode: false),
                        PersonelEmail = c.String(maxLength: 100, unicode: false),
                        PersonelParola = c.String(maxLength: 30, unicode: false),
                        PersonelDurumu = c.Boolean(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.tblYetki", t => t.YetkiId, cascadeDelete: true)
                .Index(t => t.YetkiId);
            
            AddColumn("dbo.tblMusteri", "YetkiId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblMusteri", "YetkiId");
            AddForeignKey("dbo.tblMusteri", "YetkiId", "dbo.tblYetki", "YetkiId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMusteri", "YetkiId", "dbo.tblYetki");
            DropForeignKey("dbo.tblPersonel", "YetkiId", "dbo.tblYetki");
            DropIndex("dbo.tblPersonel", new[] { "YetkiId" });
            DropIndex("dbo.tblMusteri", new[] { "YetkiId" });
            DropColumn("dbo.tblMusteri", "YetkiId");
            DropTable("dbo.tblPersonel");
            DropTable("dbo.tblYetki");
        }
    }
}
