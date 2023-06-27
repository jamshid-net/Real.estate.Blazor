﻿using HouseSale.Domain.Entities.BoolTypeEntities;

namespace HouseSale.Domain.Entities;
public class House
{
    public Guid HouseId { get; set; }
    public string Description { get; set;}
    public decimal Price { get; set; }
    public float Area { get; set; }

    public int CountOfRoom { get; set; }

    public string MainImage { get; set; }
    public virtual List<HouseImage>? Images { get; set; }



    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }



    public Guid ComfortId { get; set; }

    public virtual ThereIsInHouse Comfort { get; set; }

    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }


    public Guid CategoryRentSaleId { get; set; }
    public virtual CategoryRentSale CategoryRentSale { get; set; }

}
