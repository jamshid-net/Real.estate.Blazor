
using FluentValidation;
using HouseSale.Application;
using HouseSale.Application.Commons.Interfaces;
using HouseSale.Blazor.Services;
using HouseSale.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection;

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


        builder.Services.AddApplication();

        builder.Services.AddScoped<IUser, CurrentUser>();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddServerSideBlazor();

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllersWithViews();





      

        builder.Services.AddAuthentication().AddCookie();

        builder.Services.AddAuthorization();




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
