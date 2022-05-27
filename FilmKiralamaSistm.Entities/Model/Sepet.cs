using FilmKiralamaSistm.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Sepet
    {
        public int SepetId { get; set; }

        public int MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }


        public int FilmId { get; set; }
        public virtual Film Film { get; set; }


        public DateTime AlisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public int Miktar { get; set; }
        public int Ucret { get; set; }
       
       







    }
}

