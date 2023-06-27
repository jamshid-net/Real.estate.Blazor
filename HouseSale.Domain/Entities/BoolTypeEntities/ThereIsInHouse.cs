namespace HouseSale.Domain.Entities.BoolTypeEntities;
public class ThereIsInHouse
{
    public Guid ThereIsInHouseId { get; set; }  
    public bool Ethernet { get; set; } = false;
    public bool Phone { get; set; } = false;
    public bool Pool { get; set; } = false;
    public bool Garage { get; set; } = false;
    public bool Canalization { get; set; } = false;
    public bool GreenZone { get; set; } = false;
    public bool Security { get; set; } = false;
    public bool Cellar { get; set; } = false;
    public bool Gym { get; set; } = false;
}
