using FilmKiralama.Entities.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FilmKiralama.Entities.Mapping
{
    public class FilmMap : EntityTypeConfiguration<Film>
    {
        public FilmMap()
        {
            this.ToTable("tblFilm");
            this.Property(p => p.FilmId).HasColumnType("int");
            this.Property(p => p.FilmId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.FilmAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.YayinYili).HasColumnType("char").HasMaxLength(4);
            this.Property(p => p.ImbdPuan).HasColumnType("varchar").HasMaxLength(6);
            this.Property(p => p.FilmAciklama).HasColumnType("varchar").HasMaxLength(7000);

            this.HasRequired(p => p.Kategori).WithMany(p => p.Films).HasForeignKey(p => p.KategoriId);

        }
    }
}
