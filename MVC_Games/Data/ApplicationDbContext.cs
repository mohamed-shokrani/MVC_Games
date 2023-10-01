using Microsoft.EntityFrameworkCore;
using MVC_Games.Models;

namespace MVC_Games.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       //     base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.DeviceId, e.GameId });//Composite Key
        }
        public DbSet<GameDevice> GameDevices { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Category> Categories { get; set; }



    }
}
