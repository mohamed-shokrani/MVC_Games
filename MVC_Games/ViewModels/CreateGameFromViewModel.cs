using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC_Games.ViewModels
{
    public class CreateGameFromViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public IFormFile Cover { get; set; } = default!;

        [Display (Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]
        [Required]

        public List<int> SelectedDevices { get; set; } = default!;
        [Required]
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
