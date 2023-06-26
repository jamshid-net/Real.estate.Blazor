namespace HouseSale.Domain.Entities;
public class HouseImage
{
    public Guid ImageId { get; set; }
    public string ImagePath { get; set; }

    public Guid HouseId { get; set; }
    public virtual House House { get; set; }
}
