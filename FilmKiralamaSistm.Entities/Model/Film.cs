using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Film
    {
        public int FilmId { get; set; }
        public string FilmAdi { get; set; }
        public string FilmAciklama { get; set; }
        public string YayinYili { get; set; }
        public string ImbdPuan { get; set; }


        public bool FilmDurumu { get; set; }

        public string Fotograf { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }





    }
}
