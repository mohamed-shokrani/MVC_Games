using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MVC_Games.Data;
using MVC_Games.Interfaces;
using MVC_Games.Models;
using MVC_Games.Settings;
using MVC_Games.ViewModels;

namespace MVC_Games.Service;
public class GamesServices : IGames
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _imagesPath ;

    public GamesServices(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _db = db;
        _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
    }
    public async Task<IReadOnlyList<Game>> GetAll()
        => await _db.Games.Include(x=>x.Category).AsNoTracking().ToListAsync();
    public async Task Create(CreateGameFromViewModel model)
    {
        var cover  = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
        var path = Path.Combine(_imagesPath,cover);
        using var stream = File.Create(path);
        await model.Cover.CopyToAsync(stream);

        Game game = new()
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            Cover = cover,
            Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),

        };
        _db.Add(game);
        _db.SaveChanges();
    }
}

