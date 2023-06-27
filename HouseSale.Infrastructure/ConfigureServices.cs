using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Identity;
using HouseSale.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseSale.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
            
            
        });
        services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
           .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        

        return services;
    }
}
