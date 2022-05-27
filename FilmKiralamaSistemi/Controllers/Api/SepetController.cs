using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmKiralamaSistemi.Controllers.Api
{
    public class SepetController : ApiController
    {
        private FilmKiralamaContext db;
        public SepetController()
        {
            db = new FilmKiralamaContext();
        }
        [HttpGet]

        public IHttpActionResult GetSepets()
        {
            var sepets = db.Sepet.ToList();

            return Ok(sepets);
        }


        [HttpGet]
        public IHttpActionResult GetSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();
            return Ok(sepet);
        }

        [HttpPost]
        public IHttpActionResult AddSepet(Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Sepet.Add(pSepet);
            db.SaveChanges();
            return Ok(pSepet);
        }

        [HttpPut]
        public IHttpActionResult UpdatepSepet(int id, Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();

            sepet.Musteri.MusteriAdi = pSepet.Musteri.MusteriAdi;
            sepet.Musteri.MusteriSoyadi = pSepet.Musteri.MusteriSoyadi;
            sepet.Film.FilmAdi = pSepet.Film.FilmAdi;
            sepet.Film.FilmAdi = pSepet.Film.FilmAdi;
            sepet.TeslimTarihi = pSepet.TeslimTarihi;
            
            db.SaveChanges();

            return Ok(sepet);
        }

        [HttpDelete]
        public IHttpActionResult DeletepSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();

            db.Sepet.Remove(sepet);
            db.SaveChanges();

            return Ok();
        }



    }
}
