using FilmKiralama.Entities.Mapping;
using FilmKiralamaSistm.Entities.Mapping;
using FilmKiralamaSistm.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FilmKiralama.Entities.Model
{
    public class FilmKiralamaContext : DbContext
    {
        public FilmKiralamaContext() : base("name=FilmKiralamaEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new FilmMap());
            modelBuilder.Configurations.Add(new SepetMap());
            modelBuilder.Configurations.Add(new PersonelMap());
            modelBuilder.Configurations.Add(new YetkiMap());
           
        }


        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Yetki> Yetki { get; set; }

    }
}
