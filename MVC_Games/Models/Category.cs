using System.ComponentModel.DataAnnotations;

namespace MVC_Games.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Game> Games   { get; set; } = new List<Game>();

    }
}
