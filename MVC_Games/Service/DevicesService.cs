using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Games.Data;
using MVC_Games.Interfaces;

namespace MVC_Games.Service;
public class DevicesService :IDevices
{
    private readonly ApplicationDbContext _db;

    public DevicesService(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<SelectListItem> GetSelectListItems()
    {
        return _db.Devices.Select(x =>
                   new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                  .OrderBy(x => x.Text)
                  .AsNoTracking()
                  .ToList();
    }
}

