using System.ComponentModel.DataAnnotations;

namespace MVC_Games.Models
{
    public class Game
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]

        public string Description { get; set; } = string.Empty;
        [MaxLength(200)]

        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public   Category Category { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();


    }
}
