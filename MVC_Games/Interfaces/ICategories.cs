
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Games.Interfaces
{
    public interface ICategories
    {
        IEnumerable<SelectListItem> GetSelectListItems();
    }
}
