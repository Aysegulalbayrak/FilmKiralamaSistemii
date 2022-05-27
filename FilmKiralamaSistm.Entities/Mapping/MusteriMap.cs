using FilmKiralama.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FilmKiralamaSistm.Entities.Mapping
{
    public class MusteriMap : EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            this.ToTable("tblMusteri");
            this.Property(p => p.MusteriId).HasColumnType("int");
            this.Property(p => p.MusteriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MusteriAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriSoyadi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriEmail).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriParola).HasColumnType("varchar").HasMaxLength(30);
            this.Property(p => p.Cinsiyet).HasColumnType("varchar").HasMaxLength(30);
            this.Property(p => p.DogumTarihi).HasColumnType("date");

            this.HasRequired(p => p.Yetki).WithMany(p => p.Musteris).HasForeignKey(p => p.YetkiId);



        }


    }
}
