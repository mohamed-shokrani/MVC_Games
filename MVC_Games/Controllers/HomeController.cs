using Microsoft.AspNetCore.Mvc;
using MVC_Games.Interfaces;
using MVC_Games.Models;
using System.Diagnostics;

namespace MVC_Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGames _games;

        public HomeController(IGames games)
        {
            _games = games;
        }
        public async Task<IActionResult> Index() => View(await _games.GetAll());
  

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