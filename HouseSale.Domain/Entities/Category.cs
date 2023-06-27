namespace HouseSale.Domain.Entities;
public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public virtual List<House>? Houses { get; set; }

}   
