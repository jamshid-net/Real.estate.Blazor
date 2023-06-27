
using HouseSale.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HouseSale.Blazor;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddServerSideBlazor();

        builder.Services.AddInfrastructure(builder.Configuration);


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

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}
