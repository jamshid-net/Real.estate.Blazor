using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Domain.Entities;
public class CategoryRentSale
{
    public Guid CategoryRentSaleId { get; set; }
    public string CategoryRentSaleName { get; set; }
    public virtual List<House>? Houses { get; set; }    
}
