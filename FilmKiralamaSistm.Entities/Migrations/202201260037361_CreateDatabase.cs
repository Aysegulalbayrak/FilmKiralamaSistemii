namespace FilmKiralamaSistm.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFilm",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        FilmAdi = c.String(maxLength: 100, unicode: false),
                        FilmAciklama = c.String(maxLength: 7000, unicode: false),
                        YayinYili = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        ImbdPuan = c.String(maxLength: 6, unicode: false),
                        FilmDurumu = c.Boolean(nullable: false),
                        Fotograf = c.String(),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.tblKategori", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblKategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 100, unicode: false),
                        KategoriDurumu = c.Boolean(nullable: false),
                        KategoriAciklama = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblSepet",
                c => new
                    {
                        SepetId = c.Int(nullable: false, identity: true),
                        MusteriId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        AlisTarihi = c.DateTime(nullable: false, storeType: "date"),
                        TeslimTarihi = c.DateTime(nullable: false, storeType: "date"),
                        Miktar = c.Int(nullable: false),
                        Ucret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SepetId)
                .ForeignKey("dbo.tblFilm", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.tblMusteri", t => t.MusteriId, cascadeDelete: true)
                .Index(t => t.MusteriId)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.tblMusteri",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        MusteriAdi = c.String(maxLength: 100, unicode: false),
                        MusteriSoyadi = c.String(maxLength: 100, unicode: false),
                        MusteriEmail = c.String(maxLength: 100, unicode: false),
                        MusteriParola = c.String(maxLength: 30, unicode: false),
                        DogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        Cinsiyet = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblSepet", "MusteriId", "dbo.tblMusteri");
            DropForeignKey("dbo.tblSepet", "FilmId", "dbo.tblFilm");
            DropForeignKey("dbo.tblFilm", "KategoriId", "dbo.tblKategori");
            DropIndex("dbo.tblSepet", new[] { "FilmId" });
            DropIndex("dbo.tblSepet", new[] { "MusteriId" });
            DropIndex("dbo.tblFilm", new[] { "KategoriId" });
            DropTable("dbo.tblMusteri");
            DropTable("dbo.tblSepet");
            DropTable("dbo.tblKategori");
            DropTable("dbo.tblFilm");
        }
    }
}
