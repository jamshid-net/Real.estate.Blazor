
using Blazored.SessionStorage;

using HouseSale.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HouseSale.Blazor;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.AuthorizeFolder("/contactus");
        });



        builder.Services.AddHttpClient();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllersWithViews();


        builder.Services.AddAuthentication().AddCookie("Cookies", options =>
        {
            options.LoginPath = "/Identity/Account/Login";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            options.Cookie.MaxAge = TimeSpan.FromMinutes(10);
        });
      
        builder.Services.AddAuthorization();
       
        builder.Services.AddBlazoredSessionStorage();


        builder.Services.AddHttpContextAccessor();
        var app = builder.Build();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

       
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
           
            app.UseHsts();
        }
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();
     

        app.MapBlazorHub();
    
        app.MapFallbackToPage("/_Host");
      
        app.Run();
    }
}
