using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Games.Data;
using MVC_Games.Interfaces;
using MVC_Games.ViewModels;

namespace MVC_Games.Service;
public class CategoriesService : ICategories
{
    private readonly ApplicationDbContext _db;

    public CategoriesService(ApplicationDbContext db) => _db = db;
    public IEnumerable<SelectListItem> GetSelectListItems()
    => _db.Categories.Select(x =>
        new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
        .OrderBy(x => x.Text)
        .AsNoTracking()
        .ToList();
}

