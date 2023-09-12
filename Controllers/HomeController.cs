using FavoriteSongs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FavoriteSongs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Song(string title, string artist, double cost, int yearRecorded)
        {
            ViewData["Title"] = "Song List";
            ViewData["Message"] = "Songs: " + title;
            ViewData["Artist"] = artist;
            ViewData["Cost"] =cost;
            ViewData["Year Recorded"] = yearRecorded;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}