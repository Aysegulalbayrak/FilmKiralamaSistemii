using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralamaSistm.Entities.Model
{

    public class Yetki
    {
        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }
        public string YetkiAciklama { get; set; }
        public bool YetkiDurumu { get; set; }


        public virtual ICollection<Musteri> Musteris { get; set; }
        public virtual ICollection<Personel> Personels { get; set; }

       
    }
}


