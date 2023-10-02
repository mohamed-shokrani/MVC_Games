using Microsoft.EntityFrameworkCore;
using MVC_Games.Data;
using MVC_Games.Interfaces;
using MVC_Games.Service;

namespace MVC_Games
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            builder.Services.AddScoped<ICategories, CategoriesService>();
            builder.Services.AddScoped<IDevices, DevicesService>();
            builder.Services.AddScoped<IGames, GamesServices>();


            var app = builder.Build();
 
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Games}/{action=Create}/{id?}");

            app.Run();
        }
    }
}