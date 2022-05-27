using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmKiralamaSistemi.Controllers.Api
{
    public class FilmController : ApiController
    {
        private FilmKiralamaContext db;
        public FilmController()
        {
            db = new FilmKiralamaContext();
        }
        [HttpGet]

        public IHttpActionResult GetFilms()
        {
            var films = db.Film.Where(x => x.FilmDurumu == true).ToList();

            return Ok(films);
        }

        
        [HttpGet]
        public IHttpActionResult GetFilm(int id)
        {
            var film = db.Film.SingleOrDefault(x => x.FilmId == id);
            if (film == null)
                return NotFound();
            return Ok(film);
        }

        [HttpPost]
        public IHttpActionResult AddFilm(Film pFilm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Film.Add(pFilm);
            db.SaveChanges();
            return Ok(pFilm);
        }

        [HttpPut]
        public IHttpActionResult UpdateFilm(int id, Film pFilm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var film = db.Film.SingleOrDefault(x => x.FilmId == id);
            if (film == null)
                return NotFound();

            film.FilmAdi = pFilm.FilmAdi;
            film.FilmAciklama = pFilm.FilmAciklama;
            film.YayinYili = pFilm.YayinYili;
            film.ImbdPuan = pFilm.ImbdPuan;
            film.FilmDurumu = pFilm.FilmDurumu;
            film.Fotograf = pFilm.Fotograf;
            film.KategoriId = pFilm.KategoriId;
            db.SaveChanges();

            return Ok(film);
        }

        [HttpDelete]
        public IHttpActionResult DeleteFilm(int id)
        {
            var film = db.Film.SingleOrDefault(x => x.FilmId == id);
            if (film == null)
                return NotFound();

            db.Film.Remove(film);
            db.SaveChanges();

            return Ok();
        }



    }
}
