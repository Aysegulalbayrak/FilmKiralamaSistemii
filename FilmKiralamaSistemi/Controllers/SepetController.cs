using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmKiralamaSistemi.Controllers
{
    public class SepetController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();

        // GET: Sepet
        public ActionResult Index()
        {

            var sepet = db.Sepet.ToList();
            return View(sepet);
        }





        [HttpGet]
        public ActionResult SepeteEkle(int? id)
        {
            List<SelectListItem> filmler = db.Film.Where(x => x.FilmDurumu == true)
                                            .Select(s => new SelectListItem
                                            {
                                                Value = s.FilmId.ToString(),
                                                Text = s.FilmId.ToString() + "-" + s.FilmAdi
                                            }).ToList();

            List<SelectListItem> musteriler = db.Musteri.Where(x => x.MusteriDurumu == true)
                                           .Select(s => new SelectListItem
                                           {
                                               Value = s.MusteriId.ToString(),
                                               Text = s.MusteriAdi + " " + s.MusteriSoyadi
                                           }
                                            ).ToList();


            ViewBag.Filmler = filmler;
            ViewBag.Musteriler = musteriler;
            

            return View();
        }

        [HttpPost]
        public ActionResult SepeteEkle(Sepet pSepet)
        {
            using (FilmKiralamaContext db = new FilmKiralamaContext())
            {
                Sepet spt = new Sepet(); 
                //  ktpHrkt.Kitap = Login.Kitaps.Where(x => x.KitapId == pKitapHareket.KitapId).FirstOrDefault();
                spt.FilmId = pSepet.FilmId;
                spt.AlisTarihi = DateTime.Now;
                spt.TeslimTarihi = DateTime.Now.AddDays(7);
                spt.Film.FilmDurumu = false;
                spt.MusteriId = pSepet.MusteriId;
                //ktpHrkt.Uye = Login.Uyes.Where(x=>x.UyeId == pKitapHareket.UyeId).FirstOrDefault();
                db.Sepet.Add(spt);
                db.SaveChanges();
            }

            
            return RedirectToAction("Index");
        }

        public ActionResult TeslimAl(int id)
        {
            using (FilmKiralamaContext db = new FilmKiralamaContext())
            {
                Sepet sepet = db.Sepet.Find(id);
                sepet.Film.FilmDurumu = true;
                sepet.TeslimTarihi = DateTime.Now;
                if (sepet.AlisTarihi < DateTime.Now)
                {
                    sepet.Ucret = Convert.ToInt32((Convert.ToDateTime(DateTime.Now.ToShortDateString()) - sepet.AlisTarihi).TotalDays.ToString());
                }
                else
                {
                    sepet.Ucret = 0;
                }
                db.SaveChanges();
                
            }


            return RedirectToAction("Index");

        }


    }
}
