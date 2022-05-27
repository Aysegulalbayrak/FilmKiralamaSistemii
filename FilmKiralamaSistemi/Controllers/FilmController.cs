using FilmKiralama.Entities.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FilmKiralamaSistemi.Controllers
{
    public class FilmController : Controller
    {


        FilmKiralamaContext db = new FilmKiralamaContext();

        

        public ActionResult Index(string aranacakKelime)
        {
            var filmler = db.Film.AsNoTracking().Where(x => x.FilmDurumu == true );
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                filmler = filmler.Where(x => x.FilmAdi.Contains(aranacakKelime));
            }


            return View(filmler.ToList());
        }


        public ActionResult Sil(int id)
        {
            Film film = db.Film.Find(id);
            film.FilmDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Film film = db.Film.Find(id);


            List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.KategoriId.ToString(),
                    Text = s.KategoriAdi
                }).ToList();
            ViewBag.Kategoriler = kategoriler;
            return View(film);
        }

        [HttpPost]
        public ActionResult Guncelle(Film pFilm)
        {
            Film film = db.Film.Find(pFilm.FilmId);
            film.Fotograf = pFilm.Fotograf;
            film.FilmAdi = pFilm.FilmAdi;
            film.FilmAciklama = pFilm.FilmAciklama;
            film.Kategori = db.Kategori.Find(pFilm.Kategori.KategoriId);
            film.YayinYili = pFilm.YayinYili;
            film.ImbdPuan = pFilm.ImbdPuan;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] 

        public ActionResult Ekle()
        {

         
                List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
                   .Select(s => new SelectListItem
                   {
                       Value = s.KategoriId.ToString(),
                       Text = s.KategoriAdi
                   }).ToList();

                ViewBag.Kategoriler = kategoriler;


                return View();

        }

        [HttpPost] 
        public ActionResult Ekle(Film pFilm)
        {
            pFilm.FilmDurumu = true;
            db.Film.Add(pFilm);
            db.SaveChanges();

            return RedirectToAction("Index");
        }




        public ActionResult Detay(int id)
        {
            Film film = db.Film.Find(id);


            List<SelectListItem> kategoriler = db.Kategori.Where(x => x.KategoriDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.KategoriId.ToString(),
                    Text = s.KategoriAdi
                }).ToList();
            ViewBag.Kategoriler = kategoriler;
            return View(film);
        }




        [HttpGet]

        public ActionResult SepeteEkle()
        {



            List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
               .Select(s => new SelectListItem
               {
                   Value = s.KategoriId.ToString(),
                   Text = s.KategoriAdi
               }).ToList();

            ViewBag.Kategoriler = kategoriler;


            return View();

        }

        [HttpPost]
        public ActionResult SepeteEkle(Film pFilm, Sepet pSepet)
        {
            pFilm.FilmDurumu = false;
            db.Sepet.Add(pSepet);
            db.SaveChanges();

            return RedirectToAction("Index","Sepet");
        }

    }
}
