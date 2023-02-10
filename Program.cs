using Ben_Technical_Test.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Ben_Technical_Test.Controllers;
using Ben_Technical_Test.Helper;

namespace Ben_Technical_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddIdentity<User,IdentityRole>(options=>
            //{
            //    options.Lockout.MaxFailedAccessAttempts= 5;
            //    options.Password.RequiredLength = 6;
            //}).AddEntityFrameworkStores<UserContex>();

            //builder.Services.AddDbContext<UserContex>(options => options.UseApplicationServiceProvider();

            builder.Services.AddScoped<ArrayAuthentication>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }

    }
}