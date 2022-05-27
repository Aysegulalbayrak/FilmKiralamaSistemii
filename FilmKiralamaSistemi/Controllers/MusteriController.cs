using FilmKiralama.Entities.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmKiralamaSistemi.Controllers
{
    public class MusteriController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Musteri
        public ActionResult Index(string aranacakKelime)
        {
            var musteriler = db.Musteri.AsNoTracking().Where(x => x.MusteriDurumu == true || x.MusteriDurumu == false);
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                musteriler = musteriler.Where(x => x.MusteriAdi.Contains(aranacakKelime) || x.MusteriSoyadi.Contains(aranacakKelime));
            }


            return View(musteriler.ToList());
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
        public ActionResult Ekle(Musteri pMusteri)
        {
            pMusteri.MusteriDurumu = true;
            db.Musteri.Add(pMusteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            musteri.MusteriDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            return View(musteri);
        }
        [HttpPost]
        public ActionResult Guncelle(Musteri pMusteri)
        {
            Musteri musteri = db.Musteri.Find(pMusteri.MusteriId);
            musteri.MusteriAdi = pMusteri.MusteriAdi;
            musteri.MusteriSoyadi = pMusteri.MusteriSoyadi;
            musteri.Cinsiyet = pMusteri.Cinsiyet;
            musteri.MusteriEmail = pMusteri.MusteriEmail;
            musteri.DogumTarihi = pMusteri.DogumTarihi;
        
            musteri.MusteriDurumu = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}