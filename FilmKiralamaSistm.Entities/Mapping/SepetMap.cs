using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralamaSistm.Entities.Mapping
{

    
        public class SepetMap : EntityTypeConfiguration<Sepet>
        {
            public SepetMap()
            {
                this.ToTable("tblSepet");
                this.Property(p => p.SepetId).HasColumnType("int");
                this.Property(p => p.SepetId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.Property(p => p.AlisTarihi).HasColumnType("date");
                this.Property(p => p.TeslimTarihi).HasColumnType("date");
                this.Property(p => p.Miktar).HasColumnType("int");
                this.Property(p => p.Ucret).HasColumnType("int");

                
                this.HasRequired(p => p.Musteri).WithMany(p => p.Sepets).HasForeignKey(p => p.MusteriId);
                this.HasRequired(p => p.Film).WithMany(p => p.Sepets).HasForeignKey(p => p.FilmId);

            }
        }
    
}
