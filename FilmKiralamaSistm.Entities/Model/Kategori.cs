using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public bool KategoriDurumu { get; set; }
        public string KategoriAciklama { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
