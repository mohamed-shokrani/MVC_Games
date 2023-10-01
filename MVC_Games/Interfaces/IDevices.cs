using Microsoft.AspNetCore.Mvc.Rendering;
namespace MVC_Games.Interfaces;

public interface IDevices
{
    IEnumerable<SelectListItem> GetSelectListItems();
}

