using FilmKiralamaSistm.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralamaSistm.Entities.Mapping
{
    public class YetkiMap : EntityTypeConfiguration<Yetki>
    {
        public YetkiMap()
        {
            this.ToTable("tblYetki");
            this.Property(p => p.YetkiId).HasColumnType("int");
            this.Property(p => p.YetkiId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.YetkiAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.YetkiAciklama).HasColumnType("varchar").HasMaxLength(500);
        }
    }
}
