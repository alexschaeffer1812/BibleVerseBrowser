using BibleVerseBrowser.Models;
using BibleVerseBrowser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseBrowser.Controllers
{
    public class HomeController : Controller
    {
        public IBibleVerseRepository repository { get; set; }

        public HomeController(IBibleVerseRepository dataService)
        {
            repository = dataService;
        }

        public IActionResult Index()
        {
            var bibleVerse = repository.SearchBibleVerse(1, 1, 4);



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
