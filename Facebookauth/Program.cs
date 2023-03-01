
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography.X509Certificates;

namespace Facebookauth;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

          //public void ConfigureServices(IServiceCollection services)
          //{
            
          //  services.AddAuthentication(Options =>
          //  {
          //      Options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          //  })
          //      .AddCookie(Options =>
          //      {
          //          Options.LoginPath = "/account/facebook-ligin";
          //      })
          //      .AddFacebook(Options =>
          //      {
          //          Options.AppId = "";
          //          Options.AppSecret = "";
          //      });
          //      services.AddControllerwithViews();

          //}





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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}