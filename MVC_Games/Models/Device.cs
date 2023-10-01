using System.ComponentModel.DataAnnotations;

namespace MVC_Games.Models
{
    public class Device
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]

        public string Icon { get; set; } = string.Empty;



    }
}
