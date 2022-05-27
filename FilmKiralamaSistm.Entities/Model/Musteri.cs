using FilmKiralamaSistm.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string MusteriEmail { get; set; }
        public string MusteriParola { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }

        public int YetkiId { get; set; }
        public bool MusteriDurumu { get; set; }
        public virtual Yetki Yetki { get; set; }



        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
