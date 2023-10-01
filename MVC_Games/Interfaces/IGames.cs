using Microsoft.AspNetCore.Mvc;
using MVC_Games.Models;
using MVC_Games.ViewModels;
namespace MVC_Games.Interfaces;
public interface IGames
{
    Task<IReadOnlyList<Game>> GetAll();
    Task Create(CreateGameFromViewModel model);
}



