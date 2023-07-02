using HouseSale.Domain.Entities;
using HouseSale.Domain.Entities.BoolTypeEntities;
using HouseSale.Domain.PageEntities;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.Commons.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryRentSale> CategoryRentSales { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<HouseImage> HouseImages { get; set; }  

    public DbSet<CategoryHomeSituation> HomeSituations { get; set; }

    public DbSet<LocatedNearby> LocatedNearbies { get; set; }

    public DbSet<ThereIsInHouse> ThereIsInHouses { get; set; }

    public DbSet<PageEntity> PageEntities { get; set; } 
    public DbSet<SocialContact> SocialContacts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellation=default);

}
