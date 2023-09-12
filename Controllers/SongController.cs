using Microsoft.AspNetCore.Mvc;
using FavoriteSongs.Models;
using FavoriteSongs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FavoriteSongs.Controllers
{
    public class SongController : Controller
    {
        private SongContext context { get; set; }
        public SongController(SongContext ctx)
        {
            context = ctx;
        }

        [Authorize]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.Genres = context.Genres.OrderBy(d => d.GenreName).ToList();
            return View("Edit", new Song());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Genres = context.Genres.OrderBy(d => d.GenreName).ToList();
            var song = context.Songs.Find(id);
            return View(song);
        }
        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.Id == 0)
                {
                    context.Songs.Add(song);
                }
                else
                {
                    context.Songs.Update(song);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Song");
            }
            else
            {
                ViewBag.Genres = context.Genres.OrderBy(d => d.GenreName).ToList();

                ViewBag.Action = (song.Id == 0) ? "Add" : "Edit";
                return View(song);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            ViewBag.Action = "Delete";
            var song = context.Songs.Find(id);
            return View(song);
        }
        [HttpPost]
        public IActionResult Delete(Song song)
        {

            ViewBag.Action = "Delete";
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("Index", "Song");

        }
        public IActionResult Index(string searchString)
        {
            var songs = from e in context.Songs.Include(e => e.Genre) select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                songs = songs.Where(s => s.title.Contains(searchString));
            }
            return View(songs.ToList());
        }
        public IActionResult Genre()
        {
            return View(); ;
        }

    }
}
