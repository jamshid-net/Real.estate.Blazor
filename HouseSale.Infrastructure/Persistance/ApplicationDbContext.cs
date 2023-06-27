using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using HouseSale.Domain.Entities.BoolTypeEntities;
using HouseSale.Domain.Identity;
using HouseSale.Domain.PageEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HouseSale.Infrastructure.Persistance;
public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<House> Houses { get; set; }
    public DbSet<Category> Categories {get;set;}
    public DbSet<CategoryRentSale> CategoryRentSales {get;set;}
    public DbSet<Address> Addresses {get;set;}
    public DbSet<HouseImage> HouseImages {get;set;}
    public DbSet<HomeSituation> HomeSituations {get;set;}
    public DbSet<LocatedNearby> LocatedNearbies {get;set;}
    public DbSet<ThereIsInHouse> ThereIsInHouses {get;set;}
    public DbSet<PageEntity> PageEntities {get;set;}
    public DbSet<SocialContact> SocialContacts {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }


}
