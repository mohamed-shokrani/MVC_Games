using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Games.Data;
using MVC_Games.Models;

namespace MVC_Games.Controllers;
public class Devices : Controller
{

    private readonly ApplicationDbContext _db;
    public Devices(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index() => View(await _db.Devices.ToListAsync());

    public async Task<IActionResult> DeviceDetails(int id) => View(await _db.Devices.FindAsync(id));

    [HttpGet]
    public  IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create(Device device)
    {
        if (device == null) return new EmptyResult();
        if (!ModelState.IsValid) return View(device);

        await _db.Devices.AddAsync(device);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task< IActionResult> Edit(int id)
    {
       var device=await _db.Devices.FindAsync( id);
        if (device is null) return RedirectToAction("Index");
        return View(device);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Device device)
    {
        var findDevice = await _db.Devices.FindAsync(device.Id);//.Actors.FindAsync(id);

        if (findDevice is not null)
        {
            findDevice.Name= device.Name;
            findDevice.Icon= device.Icon;
          
            _db.Update(findDevice);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        return RedirectToAction("create");
    }
    [HttpGet]


    public IActionResult Delete(int  id)
    {
        
         _db.Devices.Where(x=>x.Id ==id).ExecuteDelete();
        return RedirectToAction("Index");
    }
}
