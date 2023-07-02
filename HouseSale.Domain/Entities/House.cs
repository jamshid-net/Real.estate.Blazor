using HouseSale.Domain.Entities.BoolTypeEntities;

namespace HouseSale.Domain.Entities;
public class House
{
    public Guid HouseId { get; set; }
    public string? Description { get; set;}
    public decimal Price { get; set; }
    public float Area { get; set; }

    public int CountOfRoom { get; set; }

    public string MainImage { get; set; }
    public virtual List<HouseImage>? HouseImages { get; set; } = new();

    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }

    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public Guid CategoryRentSaleId { get; set; }
    public virtual CategoryRentSale CategoryRentSale { get; set; }

    public Guid HomeSituationId { get; set; }
    public virtual CategoryHomeSituation? HomeSituation { get; set; }

    public Guid LocatedNearbyId { get; set; }
    public virtual LocatedNearby? LocatedNearby { get; set; }

    public Guid ThereIsInHouseId { get; set; }
    public virtual ThereIsInHouse? Comfort { get; set; }



    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }



}
