using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Games.Data;
using MVC_Games.Interfaces;
using MVC_Games.Models;
using MVC_Games.ViewModels;
using static Azure.Core.HttpHeader;

namespace MVC_Games.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICategories _categories ;
        private readonly IDevices _devices ;
        private readonly IGames _games ;

        public GamesController(ApplicationDbContext db, IGames games, ICategories categories, IDevices devices)
        {
            _games = games;
            _devices = devices ;
            _categories = categories ;
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Index() => View(await _games.GetAll());

        [HttpGet]
        public IActionResult Create()
        {

            var createGame = new CreateGameFromViewModel
            {
                Categories = _categories.GetSelectListItems(),
                Devices = _devices.GetSelectListItems()
            };
            return View(createGame);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(CreateGameFromViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
            {
                gameViewModel.Categories = _categories.GetSelectListItems();
                gameViewModel.Devices = _devices.GetSelectListItems();
                return View(gameViewModel);// return to the form 
            }

           await  _games.Create(gameViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
