using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmKiralamaSistemi.Controllers.Api
{
    public class MusteriController : ApiController
    {
        private FilmKiralamaContext db;
        public MusteriController()
        {
            db = new FilmKiralamaContext();
        }
        [HttpGet]

        public IHttpActionResult GetMusteri()
        {
            var musteris = db.Musteri.Where(x => x.MusteriDurumu == true).ToList();

            return Ok(musteris);
        }

        //parametreli Listeleme
        [HttpGet]
        public IHttpActionResult GetMusteri(int id)
        {
            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();
            return Ok(musteri);
        }

        [HttpPost]
        public IHttpActionResult AddMusteri(Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Musteri.Add(pMusteri);
            db.SaveChanges();
            return Ok(pMusteri);
        }

        [HttpPut]
        public IHttpActionResult UpdateMusteri(int id, Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();
            musteri.MusteriAdi = pMusteri.MusteriAdi;
            musteri.MusteriSoyadi = pMusteri.MusteriSoyadi;
            musteri.Cinsiyet = pMusteri.Cinsiyet;
            musteri.MusteriEmail = pMusteri.MusteriEmail;
            musteri.DogumTarihi = pMusteri.DogumTarihi;
            db.SaveChanges();

            return Ok(musteri);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMusteri(int id)
        {
            var musteri= db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();

            db.Musteri.Remove(musteri);
            db.SaveChanges();

            return Ok();
        }



    }
}
