
using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FilmKiralamaSistemi.Controllers
{
    public class KategoriController : Controller
    {

        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Kategori


        public ActionResult Index()
        {
           
                List<Kategori> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true).ToList();
                return View(kategoriler);
         

        }

        

        public ActionResult Sil(int id)
        {
            Kategori ktgr = db.Kategori.Find(id);
            
            db.Kategori.Remove(ktgr);
            db.SaveChanges();
            return RedirectToAction("index");
        }


        

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kategori pktgr)
        {
            Kategori ktgr = new Kategori();
            ktgr.KategoriAciklama = pktgr.KategoriAciklama;
            ktgr.KategoriAdi = pktgr.KategoriAdi;
            ktgr.KategoriDurumu = true;

            db.Kategori.Add(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        



        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Kategori ktgr = db.Kategori.Find(id);
            return View(ktgr);
        }
        [HttpPost]
        public ActionResult Guncelle(Kategori pKtgr)
        {
            Kategori ktgr = db.Kategori.Find(pKtgr.KategoriId);
            ktgr.KategoriAdi = pKtgr.KategoriAdi;
            ktgr.KategoriAciklama = pKtgr.KategoriAciklama;
            ktgr.KategoriDurumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategorininFilmleri(int id)
        {
            List<Film> filmler = db.Film.AsNoTracking().Where(x => x.KategoriId == id).ToList();

            return View(filmler);
        }
    }
}