using Microsoft.AspNetCore.Mvc;
using MVC_Games.Data;
using MVC_Games.Interfaces;
using MVC_Games.ViewModels;

namespace MVC_Games.Controllers 
{
    public class GamesController : Controller 
    {
        private readonly ICategories _categories ;
        private readonly IDevices _devices ;
        private readonly IGames _games ;

        public GamesController( IGames games, ICategories categories, IDevices devices)
        {
            _games = games;
            _devices = devices ;
            _categories = categories ;
        }
        [HttpGet]
      

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
